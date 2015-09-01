using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class Notification : RegistryObject
    {
        [XmlAttribute("subscription", DataType = "anyURI")]
        public string Subscription { get; set; }

        [XmlElement("RegistryObjectList")]
        public RegistryObjectList RegistryObjects { get; set; }
    }
}
