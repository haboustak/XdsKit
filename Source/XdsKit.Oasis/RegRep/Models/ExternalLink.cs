using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class ExternalLink : RegistryObject
    {
        [XmlAttribute("externalURI", DataType = "anyURI"), DefaultValue(false)]
        public string ExternalUri { get; set; }
    }
}
