using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Organization : RegistryObject
    {
        [XmlAttribute("parent", DataType = "anyURI")]
        public string Parent { get; set; }

        [XmlAttribute("primaryContact", DataType = "anyURI")]
        public string PrimaryContact { get; set; }

        [XmlElement("Address")]
        public List<PostalAddress> Addresses { get; set; }
        
        [XmlElement("TelephoneNumber")]
        public List<TelephoneNumber> TelephoneNumbers { get; set; }

        [XmlElement("EmailAddress")]
        public List<EmailAddress> EmailAddresses { get; set; }
    }
}
