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
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;

namespace ScriptCenter.Installer.Actions
{
    public class CopyFileAction : InstallerAction
    {
        [XmlAttribute("source")]
        public String Source { get; set; }

        [XmlAttribute("target")]
        public AppPaths.Directory Target { get; set; }

        [XmlAttribute("use_script_id")]
        [DefaultValue(true)]
        public Boolean UseScriptId { get; set; }

        public override bool Do(Installer installer)
        {
            try
            {
                String sourceFile = installer.InstallerDirectory + "/" + this.Source;
                String targetFile = AppPaths.GetApplicationPaths().GetPath(this.Target);
                if (this.UseScriptId)
                    targetFile += "/" + installer.Manifest.Id;

                FileInfo sourceFileInfo = new FileInfo(sourceFile);
                targetFile += "/" + sourceFileInfo.Name;
                FileInfo targetFileInfo = new FileInfo(targetFile);
                if (!targetFileInfo.Directory.Exists)
                {
                    targetFileInfo.Directory.Create();
                    installer.Log.Append("Created directory " + targetFileInfo.DirectoryName);
                }

                File.Copy(sourceFile, targetFile, true);
                installer.Log.Append("Copied file " + targetFile);
            }
            catch (Exception e)
            {
                installer.InstallerException = e;
                return false;
            }

            return true;
        }

        public override bool Undo(Installer installer)
        {
            throw new NotImplementedException();
        }
    }
}
