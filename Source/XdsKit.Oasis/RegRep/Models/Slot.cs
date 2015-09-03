using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Slot
    {
        [XmlElement("ValueList")]
        public ValueList Values { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("slotType")]
        public string SlotType { get; set; }
    }
}
