using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class ExternalIdentifier : RegistryObject
    {
        [XmlAttribute("identificationScheme", DataType = "anyURI")]
        public string IdentificationScheme { get; set; }

        [XmlAttribute("registryObject", DataType = "anyURI")]
        public string RegistryObject { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
