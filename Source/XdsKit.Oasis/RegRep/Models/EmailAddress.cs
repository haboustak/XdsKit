using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class EmailAddress
    {
        [XmlAttribute("address")]
        public string Address { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}
