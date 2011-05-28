﻿//  Copyright 2011 P.J. Janssen
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

namespace ScriptCenter.Repository
{
    public class ScriptRepository
    {
        public const String DefaultExtension = ".screpo";

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("scripts")]
        public List<ScriptManifestReference> Scripts { get; set; }

        public ScriptRepository() : this("") { }
        public ScriptRepository(String name)
        {
            this.Name = name;
            this.Scripts = new List<ScriptManifestReference>();
        }
    }

    public class ScriptManifestReference
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("uri")]
        public String URI { get; set; }

        public ScriptManifestReference() { }
        public ScriptManifestReference(String id, String uri)
        {
            this.Id = id;
            this.URI = uri;
        }
    }
}
