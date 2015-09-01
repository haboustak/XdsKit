using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class Person : RegistryObject
    {
        [XmlElement("PersonName")]
        public PersonName PersonName { get; set; }

        [XmlElement("Address")]
        public List<PostalAddress> Addresses { get; set; }

        [XmlElement("TelephoneNumber")]
        public List<TelephoneNumber> TelephoneNumbers { get; set; }

        [XmlElement("EmailAddress")]
        public List<EmailAddress> EmailAddresses { get; set; }

    }
}
