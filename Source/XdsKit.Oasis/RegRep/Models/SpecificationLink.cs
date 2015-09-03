using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class SpecificationLink : RegistryObject
    {
        [XmlAttribute("serviceBinding", DataType = "anyURI")]
        public string ServiceBinding { get; set; }

        [XmlAttribute("specificationObject", DataType = "anyURI")]
        public string SpecificationObject { get; set; }

        [XmlElement("UsageDescription")]
        public InternationalString UsageDescription { get; set; }

        [XmlElement("UsageParameter")]
        public List<string> UsageParameters { get; set; }
    }
}
