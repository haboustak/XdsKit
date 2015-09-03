using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class ServiceBinding : RegistryObject
    {
        [XmlAttribute("service", DataType="anyURI")]
        public string Service { get; set; }

        [XmlAttribute("accessURI", DataType = "anyURI")]
        public string AccessURI { get; set; }

        [XmlAttribute("targetBinding", DataType = "anyURI")]
        public string TargetBinding { get; set; }

        [XmlElement("SpecificationLink")]
        public List<SpecificationLink> SpecificationLinks { get; set; } 
    }
}
