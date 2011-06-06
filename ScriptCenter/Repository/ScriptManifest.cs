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
    public class ScriptManifest : INotifyPropertyChanged
    {
        public const String DefaultExtension = ".scmanif";

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
        
        [JsonProperty("versions")]
        public List<ScriptVersion> Versions { get; set; }

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
    }
}
