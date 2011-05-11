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
using ScriptCenter.Repository;
using System.Windows.Forms;
using ScriptCenter.Installer.Actions;

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
