using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;
using System.IO;
using ScriptCenter.Xml;

namespace ScriptCenter.Installer.NewInstallerWizard
{
    public class InstallerCreator
    {
        public void Pack(String dir, String output, ScriptManifest manifest, InstallerConfiguration config)
        {
            String[] filesToDelete = {"._*", ".DS_Store", "Thumbs.db"};
            
            try
            {
                foreach(String wildcard in filesToDelete)
                {
                    String[] files = Directory.GetFiles(dir, wildcard, SearchOption.AllDirectories);
                    foreach(String file in files)
                    {
                        File.Delete(file);
                    }
                }

                if (File.Exists(output))
                    File.Delete(output);
            } catch { }

            String str = InstallerHelperMethods.ReplaceTokens(InstallerResources.mzp, manifest);
            StreamWriter wr = new StreamWriter(dir + "/mzp.run");
            wr.Write(str);
            wr.Close();

            str = InstallerHelperMethods.ReplaceTokens(InstallerResources.install, manifest);
            wr = new StreamWriter(dir + "/install.ms");
            wr.Write(str);
            wr.Close();

            ZipFile zip = new ZipFile();
            zip.AddDirectory(dir);
            zip.AddFile(System.Reflection.Assembly.GetCallingAssembly().Location, "");
            zip.Save(output);
        }
    }
}
