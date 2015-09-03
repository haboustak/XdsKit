using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Association : RegistryObject
    {
        [XmlAttribute("associationType", DataType = "anyURI")]
        public string Type { get; set; }

        [XmlAttribute("sourceObject", DataType = "anyURI")]
        public string Source { get; set; }

        [XmlAttribute("targetObject", DataType = "anyURI")]
        public string Target { get; set; }
    }
}