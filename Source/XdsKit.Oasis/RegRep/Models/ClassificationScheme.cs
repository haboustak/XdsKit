using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class ClassificationScheme : RegistryObject
    {
        [XmlAttribute("isInternal")]
        public bool IsInternal { get; set; }

        [XmlAttribute("nodeType", DataType = "anyURI")]
        public string NodeType { get; set; }

        [XmlElement("ClassificationNode")]
        public List<ClassificationNode> Nodes { get; set; }
    }
}
