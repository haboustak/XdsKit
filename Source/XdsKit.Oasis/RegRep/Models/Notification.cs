using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Notification : RegistryObject
    {
        [XmlAttribute("subscription", DataType = "anyURI")]
        public string Subscription { get; set; }

        [XmlElement("RegistryObjectList")]
        public RegistryObjectList RegistryObjects { get; set; }
    }
}
