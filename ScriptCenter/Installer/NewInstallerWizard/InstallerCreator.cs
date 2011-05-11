//  Copyright 2011 P.J. Janssen
//  This file is part of ScriptCenter.

//  ScriptCenter is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

//  ScriptCenter is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.

//  You should have received a copy of the GNU General Public License
//  along with ScriptCenter.  If not, see <http://www.gnu.org/licenses/>.

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
        /// <summary>
        /// Packs a directory into a .mzp installer.
        /// </summary>
        /// <param name="dir">The directory with files to pack.</param>
        /// <param name="output">The location to write the .mzp file.</param>
        /// <param name="manifest">The manifest to include.</param>
        /// <param name="config">The installer configuration to include.</param>
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
