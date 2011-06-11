using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;
using ScriptCenter.Utils;
using ScriptCenter.Repository;
using ScriptCenter.Package.InstallerActions;

namespace ScriptCenter.Package
{
    public static class ScriptPacker
    {
        public const String InstallerArchivePath = "installer\\";
        public const String ResourcesArchivePath = "resources\\";

        public static Boolean Pack(ScriptPackage package)
        {
            //Write manifest.
            String manifestPath = ScriptManifestTokens.Replace(package.ManifestFile.AbsolutePath, package.Manifest, package.Manifest.LatestVersion);
            if (!ScriptPacker.writeManifest(package.Manifest, manifestPath))
                return false;

            //Loop through all versions.
            foreach (ScriptVersion v in package.Manifest.Versions)
            {
                String packagePath = ScriptManifestTokens.Replace(package.PackageFile.AbsolutePath, package.Manifest, v);

                if (v != package.Manifest.LatestVersion)
                {
                    //Skip if only latest version should be exported.
                    if (package.ExportOption == ScriptPackage.ExportOptions.LatestOnly)
                        continue;

                    //Skip if only the latest or non-existing should be exported.
                    if (package.ExportOption == ScriptPackage.ExportOptions.LatestAndNonExisting)
                    {
                        if (File.Exists(packagePath))
                            continue;
                    }
                }
                
                //Write package.
                if (!ScriptPacker.writePackage(package, v, packagePath))
                    return false;
            }

            return true;
        }



        private static Boolean writeManifest(ScriptManifest manifest, String filePath)
        {
            //Copy manifest and replace manifest tokens before writing.
            ScriptManifest manifestCopy = manifest.Copy();
            foreach (ScriptVersion v in manifestCopy.Versions)
            {
                v.ScriptPath = ScriptManifestTokens.Replace(v.ScriptPath, manifestCopy, v);
            }

            //Write manifest.
            try
            {
                JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();
                handler.Write(filePath, manifestCopy);
            }
            catch 
            {
                return false;
            }

            return true;
        }



        private static Boolean writePackage(ScriptPackage package, ScriptVersion version, String filePath)
        {
            //Create ZipFile.
            ZipFile zip = new ZipFile();

            //Add mzp.run
            zip.AddEntry("mzp.run", ScriptManifestTokens.Replace(PackageResources.mzp, package.Manifest, version), Encoding.UTF8);

            //Add install.ms
            zip.AddEntry(ScriptPacker.InstallerArchivePath + "install.ms", ScriptManifestTokens.Replace(PackageResources.install, package.Manifest, version), Encoding.UTF8);

            //Add ScriptCenter, Json and Zip assembly.
            String scAssemblyPath = System.Reflection.Assembly.GetCallingAssembly().Location;
            zip.AddFile(scAssemblyPath, ScriptPacker.InstallerArchivePath);
            zip.AddFile(Path.GetDirectoryName(scAssemblyPath) + "\\Newtonsoft.Json.Net35.dll", ScriptPacker.InstallerArchivePath);
            zip.AddFile(Path.GetDirectoryName(scAssemblyPath) + "\\Ionic.Zip.dll", ScriptPacker.InstallerArchivePath);
            
            //Add Manifest
            //Only include the supplied ScriptVersion in the package manifest.
            ScriptManifest manifest = package.Manifest.Copy();
            ScriptVersion v = version.Copy();
            v.ScriptPath = ScriptManifestTokens.Replace(v.ScriptPath, manifest, version);
            manifest.Versions = new List<ScriptVersion>() { v };
            using (StringWriter stringWriter = new StringWriter())
            {
                JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();
                handler.Write(stringWriter, manifest);
                zip.AddEntry(ScriptPacker.InstallerArchivePath + "manifest" + ScriptManifest.DefaultExtension, stringWriter.ToString());
            }

            //Add InstallerConfiguration
            using (StringWriter stringWriter = new StringWriter())
            {
                JsonFileHandler<InstallerConfiguration> handler = new JsonFileHandler<InstallerConfiguration>();
                handler.Write(stringWriter, package.InstallerConfiguration);
                zip.AddEntry(ScriptPacker.InstallerArchivePath + "config" + InstallerConfiguration.DefaultExtension, stringWriter.ToString());
            }

            //Add resources from installer actions.
            BasePath sourcePath = new BasePath(ScriptManifestTokens.Replace(package.SourcePath.AbsolutePath, package.Manifest, version));
            foreach (InstallerAction action in package.InstallerConfiguration.Actions)
            {
                action.PackResources(zip, ScriptPacker.ResourcesArchivePath, sourcePath);
            }

            //Save zip file.
            zip.Save(filePath);

            return true;
        }



        //Matches all characters that are non-alphanumeric and not a dash or space.
        private const String special_characters_filter = @"[^\w\- ]";

        //TODO: find solution for validate
        /*
        public static ValidationResult Validate(legacy_ScriptProjectData projectData)
        {
            ValidationResult result = ValidationResult.Valid;

            if (projectData == null || projectData.Manifest == null)
                return ValidationResult.Invalid;

            //Check whether rootpath is set and exists.
            if (projectData.RootPath == null || projectData.RootPath == String.Empty)
                result |= ValidationResult.RootPathEmpty;
            else if (!Directory.Exists(projectData.RootPath))
                result |= ValidationResult.RootPathNonExisting;

            //Check whether export target is set and valid.
            if (projectData.ExportTarget == null || projectData.ExportTarget == String.Empty)
                result |= ValidationResult.ExportTargetEmpty;
            else if (Regex.IsMatch(projectData.ExportTarget, @"[^\w\.\{\}\(\)\-\/\\]")) //Matches anything that is not alphanumeric, ., \, /, {. }, (, ), or -
                result |= ValidationResult.ExportTargetInvalid;

            //Check manifest name.
            if (projectData.Manifest.Name == null || projectData.Manifest.Name == String.Empty)
                result |= ValidationResult.ScriptNameEmpty;
            else if (Regex.IsMatch(projectData.Manifest.Name, special_characters_filter))
                result |= ValidationResult.ScriptNameInvalid;

            //Check manifest author.
            if (projectData.Manifest.Author == null || projectData.Manifest.Author == String.Empty)
                result |= ValidationResult.ScriptAuthorEmpty;
            else if (Regex.IsMatch(projectData.Manifest.Author, special_characters_filter))
                result |= ValidationResult.ScriptAuthorInvalid;

            //Check manifest id.
            if (projectData.Manifest.Id == null || projectData.Manifest.Id == String.Empty)
                result |= ValidationResult.ScriptIdEmpty;
            else if (Regex.IsMatch(projectData.Manifest.Id, @"[^\w\.]"))
                result |= ValidationResult.ScriptIdInvalid;

            if (result != ValidationResult.Valid)
                result |= ValidationResult.Invalid;

            return result;
        }
          
        [Flags]
        public enum ValidationResult : int
        {
            Valid               = 0,
            Invalid             = 0x0001,
            RootPathEmpty       = 0x0002,
            RootPathNonExisting = 0x0004,
            ExportTargetEmpty   = 0x0008,
            ExportTargetInvalid = 0x0010,
            ScriptNameEmpty     = 0x0020,
            ScriptNameInvalid   = 0x0040,
            ScriptAuthorEmpty   = 0x0080,
            ScriptAuthorInvalid = 0x0100,
            ScriptIdEmpty       = 0x0200,
            ScriptIdInvalid     = 0x0400
        }
        */
    }
}
