using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class TelephoneNumber
    {
        [XmlAttribute("areaCode")]
        public string AreaCode { get; set; }

        [XmlAttribute("countryCode")]
        public string CountryCode { get; set; }

        [XmlAttribute("number")]
        public string Number { get; set; }

        [XmlAttribute("extension")]
        public string Extension { get; set; }

        [XmlAttribute("phoneType")]
        public string PhoneType { get; set; }
    }
}
