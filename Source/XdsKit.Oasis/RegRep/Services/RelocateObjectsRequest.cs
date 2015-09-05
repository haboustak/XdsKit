using System.Collections.Generic;
using System.Xml.Serialization;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Services
{
    [XmlRoot(Namespace = Namespaces.Lcm)]
    public class RelocateObjectsRequest : LcmServiceRequest
    {
        [XmlElement("AdhocQuery", Namespace = Namespaces.Rim)]
        public AdhocQuery Query { get; set; }

        [XmlElement("SourceRegistry", Namespace = Namespaces.Rim)]
        public ObjectRef SourceRegistry { get; set; }

        [XmlElement("DestinationRegistry", Namespace = Namespaces.Rim)]
        public ObjectRef DestinationRegistry { get; set; }

        [XmlElement("OwnerAtSource", Namespace = Namespaces.Rim)]
        public ObjectRef OwnerAtSource { get; set; }

        [XmlElement("OwnerAtDestination", Namespace = Namespaces.Rim)]
        public ObjectRef OwnerAtDestination { get; set; } 
    }
}
