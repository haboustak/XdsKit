using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class ClassificationNode : RegistryObject
    {
        [XmlAttribute("parent", DataType = "anyURI")]
        public string Parent { get; set; }

        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }

        public List<ClassificationNode> Nodes { get; set; }
    }
}
