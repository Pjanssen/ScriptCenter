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
    public class ScriptRepository
    {
        public const String DefaultExtension = ".screpo";

        [JsonProperty("name")]
        public String Name { get; set; }
        
        [JsonProperty("categories")]
        public List<ScriptRepositoryCategory> Categories { get; private set; }

        [JsonIgnore()]
        public ScriptRepositoryCategory DefaultCategory { get; private set; }

        [JsonProperty("scripts")]
        public List<String> Scripts 
        { 
            get { return this.DefaultCategory.Scripts; }
            private set
            {
                this.DefaultCategory.Scripts = value;
            }
        }

        [JsonIgnore()]
        public List<String> AllScripts
        {
            get
            {
                List<String> scripts = new List<string>(this.Scripts);

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
    }

    public class ScriptRepositoryCategory
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("scripts")]
        public List<String> Scripts { get; set; }

        public ScriptRepositoryCategory() : this("") { }
        public ScriptRepositoryCategory(String name)
        {
            this.Name = name;
            this.Scripts = new List<String>();
        }
    }

    //TMP description of script manifest reference.
    //The path to the script manifest. This can be either a full url (for example http://domain/example.scmanifest), or a uri relative to the repository location."
}
