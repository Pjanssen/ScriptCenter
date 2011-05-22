using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptCenter.Repository;
using System.Windows.Forms;

namespace ScriptCenter.Installer.Editor
{
    public class InstallerEditorPage : UserControl
    {
        public virtual ScriptProjectData ProjectData { get; set; }
    }
}
