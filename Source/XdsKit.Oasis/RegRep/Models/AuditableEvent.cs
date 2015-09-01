using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class AuditableEvent : Identifiable
    {
        [XmlAttribute("eventType", DataType = "anyURI")]
        public string EventType { get; set; }

        [XmlAttribute("timestamp")]
        public DateTime Timestamp { get; set; }

        [XmlAttribute("user", DataType = "anyURI")]
        public string User { get; set; }

        [XmlAttribute("requestId", DataType = "anyURI")]
        public string RequestId { get; set; }

        [XmlArray("affectedObjects")]
        public List<ObjectRef> AffectedObjects { get; set; } 
    }
}
