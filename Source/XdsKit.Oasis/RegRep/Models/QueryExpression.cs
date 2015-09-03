using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class QueryExpression
    {
        [XmlAttribute("queryLanguage", DataType = "anyURI")]
        public string QueryLanguage { get; set; }

        [XmlText]
        public string Query { get; set; }
    }
}
