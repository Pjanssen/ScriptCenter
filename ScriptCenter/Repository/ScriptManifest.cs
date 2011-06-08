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
using System.Runtime.Serialization.Formatters.Binary;

namespace ScriptCenter.Repository
{
    /// <summary>
    /// The ScriptManifest contains information about a script and its versions.
    /// </summary>
    [Serializable]
    public class ScriptManifest : INotifyPropertyChanged
    {
        public const String DefaultExtension = ".scmanif";

        private String _id;
        private String _name;
        private String _author;

        [JsonProperty("id")]
        public String Id 
        {
            get { return this._id; }
            set
            {
                this._id = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }

        [JsonProperty("name")]
        public String Name 
        {
            get { return this._name; }
            set
            {
                this._name = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }
        
        [JsonProperty("author")]
        public String Author 
        {
            get { return this._author; }
            set
            {
                this._author = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Author"));
            }
        }
        
        [JsonProperty("versions")]
        public List<ScriptVersion> Versions { get; set; }

        [JsonIgnore]
        public ScriptVersion LatestVersion
        {
            get 
            {
                if (this.Versions == null || this.Versions.Count == 0)
                    return null;
                return this.Versions.OrderByDescending(v => v.VersionNumber).First(); 
            }
        }

        [JsonIgnore]
        public ScriptVersion LatestStableVersion
        {
            get
            {
                if (this.Versions == null || this.Versions.Count == 0)
                    return null;
                return this.Versions.OrderByDescending(v => v.VersionNumber).First(v => v.VersionNumber.ReleaseStage == ScriptReleaseStage.Release);
            }
        }

        [JsonProperty("metadata")]
        public Dictionary<String, String> Metadata { get; set; }


        public ScriptManifest() 
        {
            this.Id = String.Empty;
            this.Name = String.Empty;
            this.Versions = new List<ScriptVersion>();
            this.Metadata = new Dictionary<String, String>();
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }

        #endregion

        
        /// <summary>
        /// Creates a deep-copy of the ScriptManifest object.
        /// </summary>
        public ScriptManifest Copy()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            formatter.Serialize(memStream, this);
            memStream.Position = 0;
            return (ScriptManifest)formatter.Deserialize(memStream);
        }
    }
}
