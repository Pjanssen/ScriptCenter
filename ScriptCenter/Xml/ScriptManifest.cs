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

namespace ScriptCenter.Xml
{
    /// <summary>
    /// The ScriptManifest contains information about a script and its versions.
    /// </summary>
    [XmlRoot("script_manifest")]
    public class ScriptManifest
    {
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

        public List<ScriptVersion> Versions { get; set; }
        

        public ScriptManifest()
        {
            this.Info = new ScriptInfo();
            this.Versions = new List<ScriptVersion>();
        }
    }

    public class ScriptInfo
    {
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

        [XmlElement("requirements")]
        public ScriptRequirements Requirements { get; set; }

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
        [XmlAttribute("max_3dsmax_version")]
        public Int32 Maximum3dsmaxVersion { get; set; }
        [XmlAttribute("min_dotnet_version")]
        public float MinimalDotNetVersion { get; set; }
    }
}
