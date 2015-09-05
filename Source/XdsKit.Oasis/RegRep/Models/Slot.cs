using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Slot
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("slotType", DataType="anyURI")]
        public string Type { get; set; }

        [XmlArray("ValueList"), XmlArrayItem("Value")]
        public List<string> Values { get; set; }
    }
}
