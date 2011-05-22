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
using Newtonsoft.Json;
using System.ComponentModel;

namespace ScriptCenter.Repository
{
    /// <summary>
    /// The ScriptManifest contains information about a script and its versions.
    /// </summary>
    [XmlRoot("script_manifest")]
    public class ScriptManifest : INotifyPropertyChanged
    {
        public const String DefaultExtension = ".scmanifest";

        private String id;
        [JsonProperty("id")]
        public String Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }

        private String name;
        [JsonProperty("name")]
        public String Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }


        private String author;
        [JsonProperty("author")]
        public String Author
        {
            get { return this.author; }
            set
            {
                this.author = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Author"));
            }
        }

        private String description;
        [JsonProperty("description")]
        public String Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Descriptions"));
            }
        }

        [JsonProperty("version")]
        public ScriptVersion Version { get; set; }

        [JsonProperty("versions")]
        public List<ScriptVersion> Versions { get; set; }
        

        public ScriptManifest()
        {
            this.Id = String.Empty;
            this.Name = String.Empty;
            this.Versions = new List<ScriptVersion>();
            this.Version = new ScriptVersion();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }

        #endregion
    }


    public class ScriptVersion
    {
        [JsonIgnore()]
        [XmlIgnore()]
        public Int32 Major { get; set; }

        [JsonIgnore()]
        [XmlIgnore()]
        public Int32 Minor { get; set; }

        [JsonIgnore()]
        [XmlIgnore()]
        public Int32 Revision { get; set; }

        [JsonProperty("requirements")]
        [XmlElement("requirements")]
        public ScriptRequirements Requirements { get; set; }

        [JsonProperty("version")]
        [XmlAttribute("version")]
        public String Version
        {
            get { return this.Major.ToString() + "." + this.Minor.ToString() + "." + this.Revision.ToString(); }
            set
            {
                try
                {
                    Int32 a = value.IndexOf('.');
                    Int32 b = value.LastIndexOf('.');
                    this.Major = Int32.Parse(value.Substring(0, a));
                    this.Minor = Int32.Parse(value.Substring(a + 1, b - (a + 1)));
                    this.Revision = Int32.Parse(value.Substring(b + 1));
                }
                catch (Exception e)
                {
                    this.Major = 0;
                    this.Minor = 0;
                    this.Revision = 0;
                    Console.WriteLine(e.Message);
                }
            }
        }

        public ScriptVersion() 
        {
            this.Requirements = new ScriptRequirements();
        }
        public ScriptVersion(Int32 major, Int32 minor, Int32 revision) : this()
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
