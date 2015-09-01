using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class PostalAddress
    {
        [XmlAttribute("city")]
        public string City { get; set; }

        [XmlAttribute("country")]
        public string Country { get; set; }

        [XmlAttribute("postalCode")]
        public string PostalCode { get; set; }

        [XmlAttribute("stateOrProvince")]
        public string StateOrProvince { get; set; }

        [XmlAttribute("street")]
        public string Street { get; set; }

        [XmlAttribute("streetNumber")]
        public string StreetNumber { get; set; }
    }
}
