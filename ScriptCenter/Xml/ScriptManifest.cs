using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ScriptCenter.Xml
{
    [XmlRoot("script_manifest")]
    public class ScriptManifest
    {
        [XmlAttribute("manifest_online_uri")]
        public String ManifestOnlineURI { get; set; }
        [XmlAttribute("manifest_local_uri")]
        public String ManifestLocalURI { get; set; }

        [XmlElement("id")]
        public String Id { get; set; }
        [XmlElement("name")]
        public String Name { get; set; }
        [XmlElement("icon_small")]
        public String IconSmallRawData { get; set; }
        [XmlIgnore()]
        public System.Drawing.Image IconSmall
        {
            get
            {
                if (this.IconSmallRawData == null)
                    return null;
                else
                {
                    Byte[] iconBytes = Convert.FromBase64String(this.IconSmallRawData);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(iconBytes, false);
                    return System.Drawing.Image.FromStream(ms);
                }
            }
        }

        [XmlElement("info")]
        public ScriptInfo Info { get; set; }
        [XmlElement("version")]
        public ScriptVersion Version { get; set; }
        public List<ScriptVersion> Versions { get; set; }
        [XmlElement("requirements")]
        public ScriptRequirements Requirements { get; set; }


        public ScriptManifest()
        {
            this.Info = new ScriptInfo();
            this.Version = new ScriptVersion();
            this.Requirements = new ScriptRequirements();
        }
    }

    public class ScriptInfo
    {
        [XmlAttribute("category")]
        public String Category { get; set; }
        [XmlAttribute("author")]
        public String Author { get; set; }
        [XmlAttribute("description")]
        public String Description { get; set; }
        [XmlAttribute("icon_uri")]
        public String IconURI { get; set; }
    }

    public class ScriptVersion
    {
        [XmlAttribute("major")]
        public Int32 Major { get; set; }
        [XmlAttribute("minor")]
        public Int32 Minor { get; set; }
        [XmlAttribute("revision")]
        public Int32 Revision { get; set; }

        public float ToFloat()
        {
            float f = (float)this.Major;
            f += this.Minor / 100f;
            f += this.Revision / 10000f;
            return f;
        }
        public override string ToString()
        {
            return this.Major.ToString() + "." + this.Minor.ToString() + "." + this.Revision.ToString();
        }

        public ScriptVersion() { }
        public ScriptVersion(Int32 major, Int32 minor, Int32 revision)
        {
            this.Major = major;
            this.Minor = minor;
            this.Revision = revision;
        }
    }

    public class ScriptRequirements
    {
        [XmlAttribute("min_3dsmax_version")]
        public Int32 Minimal3dsmaxVersion { get; set; }
        [XmlAttribute("min_dotnet_version")]
        public float MinimalDotNetVersion { get; set; }
    }
}
