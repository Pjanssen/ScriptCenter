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

namespace ScriptCenter.Repository
{
    [XmlRoot("script_repository")]
    public class ScriptRepository
    {
        public const String DefaultExtension = ".screpo";

        [JsonProperty("name")]
        [XmlElement("name")]
        public String Name { get; set; }

        [JsonProperty("scripts")]
        [XmlArray("scripts")]
        [XmlArrayItem("script")]
        public List<ScriptManifestReference> Scripts { get; set; }

        public ScriptRepository()
        {
            this.Scripts = new List<ScriptManifestReference>();
        }
        public ScriptRepository(String name) : this()
        {
            this.Name = name;
        }
    }

    public class ScriptManifestReference
    {
        [JsonProperty("id")]
        [XmlAttribute("id")]
        public String Id { get; set; }

        [JsonProperty("uri")]
        [XmlAttribute("uri")]
        public String URI { get; set; }

        public ScriptManifestReference() { }
        public ScriptManifestReference(String id, String uri)
        {
            this.Id = id;
            this.URI = uri;
        }
    }
}
