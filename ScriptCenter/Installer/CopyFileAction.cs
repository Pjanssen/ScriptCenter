using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;

namespace ScriptCenter.Installer
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
