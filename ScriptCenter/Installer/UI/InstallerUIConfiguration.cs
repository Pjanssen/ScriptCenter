using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using Newtonsoft.Json;
using ScriptCenter.Repository;

namespace ScriptCenter.Installer.UI
{
    public class InstallerUIConfiguration
    {
        public const String DefaultExtension = ".scinstallerui";

        public InstallerUIConfiguration()
        {
            InstallerHelperMethods.SetDefaultValues(this);
        }

        public static InstallerUIConfiguration FromFile(String file)
        {
            JsonFileHandler<InstallerUIConfiguration> handler = new JsonFileHandler<InstallerUIConfiguration>();
            return handler.Read(file);
        }

        [JsonProperty("title")]
        [XmlElement("title")]
        [DefaultValue(InstallerHelperMethods.Name_Token + " "+ InstallerHelperMethods.Version_Token)]
        public String Title { get; set; }

        [JsonProperty("start_page_text")]
        [XmlElement("start_page_text")]
        [DefaultValue("This script will install the " + InstallerHelperMethods.Name_Token + " " + InstallerHelperMethods.Version_Token +  ". Any previous installations will automatically be uninstalled.")]
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
