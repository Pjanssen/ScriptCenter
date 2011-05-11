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
    [XmlRoot("script_repository_list")]
    public class ScriptRepositoryList
    {
        [XmlElement("repository")]
        public List<ScriptRepositoryReference> Repositories { get; set; }

        public ScriptRepositoryList()
        {
            this.Repositories = new List<ScriptRepositoryReference>();
        }
    }

    public class ScriptRepositoryReference
    {
        [XmlAttribute("name")]
        public String Name { get; set; }
        [XmlAttribute("uri")]
        public String URI { get; set; }

        public ScriptRepositoryReference() { }
        public ScriptRepositoryReference(String name, String uri)
        {
            this.Name = name;
            this.URI = uri;
        }
    }
}
