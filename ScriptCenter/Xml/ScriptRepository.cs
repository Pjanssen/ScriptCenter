using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ScriptCenter.Xml
{
    [XmlRoot("script_repository")]
    public class ScriptRepository
    {
        [XmlElement("name")]
        public String Name { get; set; }

        [XmlArray("scripts")]
        [XmlArrayItem("script")]
        public List<ScriptManifestReference> Scripts { get; set; }

        public ScriptRepository()
        {
            this.Scripts = new List<ScriptManifestReference>();
        }
        public ScriptRepository(String name)
            : this()
        {
            this.Name = name;
        }
    }

    public class ScriptManifestReference
    {
        [XmlAttribute("id")]
        public String Id { get; set; }
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
