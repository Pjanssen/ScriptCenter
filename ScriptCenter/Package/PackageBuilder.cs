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
    public class PackageBuilder
    {
        public const String InstallerArchivePath = "installer\\";
        public const String ResourcesArchivePath = "resources\\";

        protected ZipFile _currentZipFile;
        

        /// <summary>
        /// Writes a ScriptManifest to a file.
        /// </summary>
        /// <param name="manifest">The ScriptManifest to write.</param>
        /// <param name="filePath">The IPath instance of the file to write to.</param>
        /// <returns>True upon success.</returns>
        /// <remarks>Consider removing from this class.</remarks>
        public Boolean WriteManifest(ScriptManifest manifest, IPath filePath) 
        {
            //Copy manifest and replace manifest tokens before writing.
            ScriptManifest manifestCopy = manifest.Copy();
            foreach (ScriptVersion v in manifestCopy.Versions)
            {
                v.ScriptPath = ScriptManifestTokens.Replace(v.ScriptPath, manifestCopy, v);
            }

            //Write manifest.
            filePath.AbsolutePath = ScriptManifestTokens.Replace(filePath.AbsolutePath, manifest, manifest.LatestVersion);
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


        /// <summary>
        /// Writes a package to a file.
        /// </summary>
        /// <param name="package">The package to write.</param>
        /// <param name="exportOptions">The overwrite options for the write operation.</param>
        /// <returns></returns>
        public Boolean BuildAndWritePackage(ScriptPackage package, PackageExportOptions exportOptions)
        {
            //Loop through all versions.
            foreach (ScriptVersion version in package.Manifest.Versions)
            {
                String packagePath = ScriptManifestTokens.Replace(package.PackageFile.AbsolutePath, package.Manifest, version);

                if (version != package.Manifest.LatestVersion)
                {
                    //Skip if only latest version should be exported.
                    if ((exportOptions & PackageExportOptions.LatestOnly) == PackageExportOptions.LatestOnly)
                        continue;

                    //Skip if only the latest or non-existing should be exported.
                    if ((exportOptions & PackageExportOptions.LatestAndNonExisting) == PackageExportOptions.LatestAndNonExisting)
                    {
                        if (File.Exists(packagePath))
                            continue;
                    }
                }

                _currentZipFile = new ZipFile();

                this.AddAssemblies();
                this.AddMzpFiles(package.Manifest, version);
                this.AddManifest(package.Manifest, version);
                this.AddInstallerConfiguration(package.InstallerConfiguration);
                this.AddInstallerActionResources(package, version);

                try
                {
                    _currentZipFile.Save(packagePath);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Adds the MZP files (readme, mzp.run, install.ms) to the zip package.
        /// </summary>
        /// <param name="manifest">The ScriptManifest to use to replace tokens in the mzp files.</param>
        /// <param name="version">The ScriptVersion to use to replace tokens in the mzp files.</param>
        public virtual void AddMzpFiles(ScriptManifest manifest, ScriptVersion version)
        {
            //Add mzp.run
            _currentZipFile.AddEntry("mzp.run", ScriptManifestTokens.Replace(PackageResources.mzp, manifest, version), Encoding.ASCII);

            //Add readme.txt
            _currentZipFile.AddEntry("README.txt", ScriptManifestTokens.Replace(PackageResources.README, manifest, version), Encoding.UTF8);

            //Add install.ms
            _currentZipFile.AddEntry(PackageBuilder.InstallerArchivePath + "install.ms", ScriptManifestTokens.Replace(PackageResources.install, manifest, version), Encoding.ASCII);
        }


        /// <summary>
        /// Adds assemblies required for the installer to the zip package.
        /// </summary>
        public virtual void AddAssemblies()
        {
            //Add ScriptCenter dll.
            String scAssemblyPath = System.Reflection.Assembly.GetCallingAssembly().Location;
            _currentZipFile.AddFile(scAssemblyPath, PackageBuilder.InstallerArchivePath);

            //Add NewtonSoft JSON dll.
            _currentZipFile.AddFile(Path.GetDirectoryName(scAssemblyPath) + "\\Newtonsoft.Json.Net35.dll", PackageBuilder.InstallerArchivePath);

            //Add Zip dll.
            _currentZipFile.AddFile(Path.GetDirectoryName(scAssemblyPath) + "\\Ionic.Zip.dll", PackageBuilder.InstallerArchivePath);
        }


        /// <summary>
        /// Adds the ScriptManifest to the zip package.
        /// Only includes the supplied ScriptVersion in the package manifest versions list.
        /// </summary>
        /// <param name="manifest">The ScriptManifest instance to add.</param>
        /// <param name="version">The ScriptVersion to filter out from the manifest. All other versions will not be included.</param>
        public virtual void AddManifest(ScriptManifest manifest, ScriptVersion version)
        {
            ScriptManifest manifestCopy = manifest.Copy();
            ScriptVersion versionCopy = version.Copy();
            versionCopy.ScriptPath = ScriptManifestTokens.Replace(versionCopy.ScriptPath, manifest, version);
            manifestCopy.Versions = new List<ScriptVersion>() { versionCopy };
            using (StringWriter stringWriter = new StringWriter())
            {
                JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();
                handler.Write(stringWriter, manifestCopy);
                //TODO: change this to work with multiple manifests?
                _currentZipFile.AddEntry(PackageBuilder.InstallerArchivePath + "script" + ScriptManifest.DefaultExtension, stringWriter.ToString());
            }
        }


        /// <summary>
        /// Adds the InstallerConfiguration to the zip package.
        /// </summary>
        /// <param name="config">The InstallerConfiguration instance to add.</param>
        public virtual void AddInstallerConfiguration(InstallerConfiguration config)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                JsonFileHandler<InstallerConfiguration> handler = new JsonFileHandler<InstallerConfiguration>();
                handler.Write(stringWriter, config);
                _currentZipFile.AddEntry(PackageBuilder.InstallerArchivePath + "script" + InstallerConfiguration.DefaultExtension, stringWriter.ToString());
            }
        }


        /// <summary>
        /// Adds the resources for all InstallerActions to the zip package.
        /// </summary>
        public virtual void AddInstallerActionResources(ScriptPackage package, ScriptVersion version)
        {
            BasePath sourcePath = new BasePath(ScriptManifestTokens.Replace(package.SourcePath.AbsolutePath, package.Manifest, version));
            foreach (InstallerAction action in package.InstallerConfiguration.Actions)
            {
                action.PackResources(_currentZipFile, PackageBuilder.ResourcesArchivePath, sourcePath);
            }
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
