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
using ScriptCenter.Utils;

namespace ScriptCenter.Repository
{
    public class ScriptRepository : INotifyPropertyChanged
    {
        public const String DefaultExtension = ".screpo";

        [JsonProperty("scversion")]
        public Int32 SCVersion { get; set; }

        private String _name;
        [JsonProperty("name")]
        public String Name 
        {
            get { return _name; }
            set
            {
                _name = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }
        
        [JsonProperty("categories")]
        public List<ScriptRepositoryCategory> Categories { get; private set; }

        [JsonIgnore()]
        public ScriptRepositoryCategory DefaultCategory { get; private set; }

        [JsonProperty("scripts")]
        public List<ScriptManifestReference> Scripts 
        { 
            get { return this.DefaultCategory.Scripts; }
            private set
            {
                this.DefaultCategory.Scripts = value;
            }
        }

        [JsonIgnore()]
        public List<ScriptManifestReference> AllScripts
        {
            get
            {
                List<ScriptManifestReference> scripts = new List<ScriptManifestReference>(this.Scripts);

                foreach (ScriptRepositoryCategory cat in this.Categories)
                    scripts.AddRange(cat.Scripts);

                return scripts;
            }
        }

        public ScriptRepository() : this("") { }
        public ScriptRepository(String name)
        {
            this.Name = name;
            this.DefaultCategory = new ScriptRepositoryCategory("__default__");
            this.Categories = new List<ScriptRepositoryCategory>();
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }
    }

    public class ScriptRepositoryCategory
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("scripts")]
        public List<ScriptManifestReference> Scripts { get; set; }

        public ScriptRepositoryCategory() : this("") { }
        public ScriptRepositoryCategory(String name)
        {
            this.Name = name;
            this.Scripts = new List<ScriptManifestReference>();
        }
    }


    [JsonConverter(typeof(StringJsonConverter))]
    public class ScriptManifestReference
    {
        public IPath Uri { get; set; }

        public ScriptManifestReference() : this("") { }
        public ScriptManifestReference(String uri)
        {
            this.Uri = new BasePath(uri);
        }

        public override string ToString()
        {
            return this.Uri.AbsolutePath;
        }
    }
}
