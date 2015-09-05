using System.ComponentModel;
using System.Xml.Serialization;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Services
{
    [XmlRoot(Namespace = Namespaces.Query)]
    public class AdhocQueryRequest : QueryServiceRequest
    {
        [XmlAttribute("federated"), DefaultValue(false)]
        public bool Federated { get; set; }

        public bool FederatedSpecified { get { return !Federated; } }
        
        [XmlAttribute("federation", DataType="anyURI")]
        public string Federation { get; set; }

        [XmlAttribute("startIndex"), DefaultValue(0)]
        public int StartIndex { get; set; }

        public bool StartIndexSpecified { get { return StartIndex != -1; } }

        [XmlAttribute("maxResults"), DefaultValue(-1)]
        public int MaxResults { get; set; }
        
        public bool MaxResultsSpecified { get { return MaxResults != -1; } }

        [XmlElement("ResponseOption")]
        public ResponseOption ResponseOption { get; set; }

        [XmlElement("AdhocQuery", Namespace=Namespaces.Rim)]
        public AdhocQuery Query { get; set; }

        public AdhocQueryRequest()
        {
            StartIndex = 0;
            MaxResults = -1;
        }
    }
}
