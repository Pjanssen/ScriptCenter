using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;
using ScriptCenter.Utils;
using ScriptCenter.Repository;

namespace ScriptCenter.Package
{
    public static class ScriptPacker
    {
        public static Boolean Pack(ScriptPackage package)
        {
            //Write manifest.
            if (!ScriptPacker.writeManifest(package.Manifest, ScriptManifestTokens.Replace(package.ManifestFile.Path, package.Manifest)))
                return false;

            //Write mzp.
            if (!ScriptPacker.writePackage(package))
                return false;

            return true;
        }

        private static Boolean writeManifest(ScriptManifest manifest, String file)
        {
            //Copy manifest and replace manifest tokens before writing.
            ScriptManifest manifestCopy = manifest.Copy();
            foreach (ScriptVersion v in manifestCopy.Versions)
            {
                v.ScriptPath = ScriptManifestTokens.Replace(v.ScriptPath, manifestCopy);
            }

            //Write manifest.
            try
            {
                JsonFileHandler<ScriptManifest> handler = new JsonFileHandler<ScriptManifest>();
                handler.Write(file, manifestCopy);
            }
            catch 
            {
                return false;
            }

            return true;
        }


        private static Boolean writePackage(ScriptPackage package)
        {
            //Create temp directory.
            String tempPath = Path.GetTempPath() + "ScriptCenter\\";
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            //Create ZipFile, add temp directory contents, add assemblies, save file.
            ZipFile zip = new ZipFile();
            zip.AddDirectory(tempPath);
            String scAssemblyPath = System.Reflection.Assembly.GetCallingAssembly().Location;
            zip.AddFile(scAssemblyPath, "");
            zip.AddFile(Path.GetDirectoryName(scAssemblyPath) + "\\Newtonsoft.Json.Net35.dll", "");
            zip.Save(ScriptManifestTokens.Replace(package.PackageFile.Path, package.Manifest));

            //Remove temp dir
            Directory.Delete(tempPath, true);

            return true;
        }
    }
}
