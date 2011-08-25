using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptCenter.Utils;

namespace ScriptCenter.Package.InstallerActions
{
    public class InstallPackageAction : InstallerAction
    {
        public override bool Do(Installer installer)
        {
            throw new NotImplementedException();
        }

        public override bool Undo(Installer installer)
        {
            throw new NotImplementedException();
        }

        public override void PackResources(Ionic.Zip.ZipFile zip, string archiveTargetPath, IPath sourcePath)
        {
            throw new NotImplementedException();
        }

        public override string ActionName { get { return "Install Package"; } }
    }
}
