using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Identifiable
    {
        [XmlAttribute("id", DataType = "anyURI")]
        public string Id { get; set; }

        [XmlAttribute("home", DataType = "anyURI")]
        public string Home { get; set; }

        [XmlElement("Slot")]
        public List<Slot> Slots { get; set; }

        public Identifiable()
        {
            Slots = new List<Slot>();
        }
    }
}
