using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ScriptCenter.Installer.UI
{
    public class InstallerUIConfiguration
    {
        public InstallerUIConfiguration()
        {
            InstallerHelperMethods.SetDefaultValues(this);
        }

        [JsonProperty("title")]
        [XmlElement("title")]
        [DefaultValue("{script_name} {script_version}")]
        public String Title { get; set; }

        [JsonProperty("start_page_text")]
        [XmlElement("start_page_text")]
        [DefaultValue("This script will install the {script_name} {script_version}. Any previous installations will automatically be uninstalled.")]
        public String StartPageText { get; set; }

        [JsonProperty("icon")]
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
