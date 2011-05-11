using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using ScriptCenter.Xml;
using System.Windows.Forms;

namespace ScriptCenter.Installer
{
    [XmlRoot("installer_configuration")]
    public class InstallerConfiguration
    {
        public InstallerConfiguration()
        {
            this.InstallerActions = new List<InstallerAction>();
            this.StartPageUI = new InstallerStartPageUI();
        }

        [XmlArray("installer_actions")]
        [XmlArrayItem("copy_dir", typeof(CopyDirAction))]
        [XmlArrayItem("assign_hotkey", typeof(AssignHotkeyAction))]
        public List<InstallerAction> InstallerActions { get; set; }

        [XmlElement("start_page_ui")]
        public InstallerStartPageUI StartPageUI { get; set; }
    }

    public class InstallerStartPageUI
    {
        public InstallerStartPageUI()
        {
            InstallerHelperMethods.SetDefaultValues(this);
        }

        [XmlElement("title")]
        [DefaultValue("{script_name} {script_version}")]
        public String Title { get; set; }

        [XmlElement("text")]
        [DefaultValue("This script will install the {script_name} {script_version}. Any previous installations will automatically be uninstalled.")]
        public String Text { get; set; }

        [XmlElement("icon")]
        public String IconRawData { get; set; }
        [XmlIgnore()]
        public System.Drawing.Image Icon
        {
            get
            {
                if (this.IconRawData == null)
                    return null;
                else
                {
                    Byte[] iconBytes = Convert.FromBase64String(this.IconRawData);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(iconBytes, false);
                    return System.Drawing.Image.FromStream(ms);
                }
            }
        }
    }
}
