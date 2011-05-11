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
