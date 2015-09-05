using System.Collections.Generic;
using System.Xml.Serialization;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Services
{
    public abstract class ObjectStatusRequest : LcmServiceRequest
    {
        [XmlElement("AdhocQuery", Namespace = Namespaces.Rim)]
        public AdhocQuery Query { get; set; }

        [XmlArray("ObjectRefList", Namespace = Namespaces.Rim)]
        public List<ObjectRef> Objects { get; set; } 
    }
}
