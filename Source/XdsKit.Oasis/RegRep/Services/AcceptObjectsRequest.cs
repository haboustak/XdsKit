using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Services
{
    [XmlRoot(Namespace = Namespaces.Lcm)]
    public class AcceptObjectsRequest : LcmServiceRequest
    {
        [XmlAttribute("correlationId", DataType="anyURI")]
        public string CorrelationId { get; set; }
    }
}
