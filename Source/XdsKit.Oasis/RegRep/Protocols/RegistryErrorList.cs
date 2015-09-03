using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Protocols
{
    [XmlRoot(Namespace = Namespaces.Rs)]
    public class RegistryErrorList
    {
        [XmlAttribute("highestSeverity")]
        public string HighestSeverity { get; set; }

        public List<RegistryError> RegistryErrors { get; set; }
    }
}