using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Classification : RegistryObject
    {
        [XmlAttribute("classificationScheme", DataType = "anyURI")]
        public string ClassificationScheme { get; set; }

        [XmlAttribute("classifiedObject", DataType = "anyURI")]
        public string ClassifiedObject { get; set; }

        [XmlAttribute("classificationNode", DataType = "anyURI")]
        public string ClassificationNode { get; set; }

        [XmlAttribute("nodeRepresentation")]
        public string NodeRepresentation { get; set; }
    }
}