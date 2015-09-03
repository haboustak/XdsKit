using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class PersonName
    {
        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("middleName")]
        public string MiddleName { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }
    }
}
