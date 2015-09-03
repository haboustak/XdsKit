using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class AdhocQuery : RegistryObject
    {
        [XmlElement("QueryExpression")]
        public QueryExpression QueryExpression { get; set; }
    }
}
