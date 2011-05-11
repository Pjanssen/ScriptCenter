using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptCenter.Installer
{
    public abstract class InstallerAction
    {
        public abstract Boolean Do(Installer installer);
        public abstract Boolean Undo(Installer installer);
    }
}
