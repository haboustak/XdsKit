using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Federation : RegistryObject
    {
        [XmlAttribute("replicationSyncLatency", DataType = "duration"), DefaultValue("P1D")]
        public string ReplicationSyncLatencyValue
        {
            get { return XmlConvert.ToString(ReplicationSyncLatency); }
            set { ReplicationSyncLatency = value.AsTimeSpan("P1D"); }
        }

        [XmlIgnore]
        public bool ReplicationSyncLatencyValueSpecified
        {
            get { return ReplicationSyncLatency != new TimeSpan(1, 0, 0, 0); }
        }

        [XmlIgnore]
        public TimeSpan ReplicationSyncLatency { get; set; }

        public Federation()
        {
            ReplicationSyncLatency = "P1D".AsTimeSpan();
        }
    }
}
