using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Registry : RegistryObject
    {
        [XmlAttribute("operator", DataType="anyURI")]
        public string Operator { get; set; }

        [XmlAttribute("specificationVersion")]
        public string SpecificationVersion { get; set; }

        [XmlAttribute("replicationSyncLatency", DataType = "duration"), DefaultValue("P1D")]
        public string ReplicationSyncLatencyValue
        {
            get { return XmlConvert.ToString(ReplicationSyncLatency);  }
            set { ReplicationSyncLatency = value.AsTimeSpan("P1D"); }
        }

        [XmlIgnore]
        public bool ReplicationSyncLatencyValueSpecified
        {
            get { return ReplicationSyncLatency != new TimeSpan(1, 0, 0, 0); }
        }

        [XmlAttribute("catalogingLatency", DataType = "duration"), DefaultValue("P1D")]
        public string CatalogingLatencyValue
        {
            get { return XmlConvert.ToString(CatalogingLatency); }
            set { CatalogingLatency = value.AsTimeSpan("P1D"); }
        }

        [XmlIgnore]
        public bool CatalogingLatencyValueSpecified
        {
            get { return CatalogingLatency != new TimeSpan(1, 0, 0, 0); }
        }

        [XmlAttribute("conformanceProfile")]
        public string ConformanceProfile { get; set; }

        [XmlIgnore]
        public TimeSpan ReplicationSyncLatency { get; set; }

        [XmlIgnore]
        public TimeSpan CatalogingLatency { get; set; }

        public Registry()
        {
            ReplicationSyncLatency = "P1D".AsTimeSpan();
            CatalogingLatency = "P1D".AsTimeSpan();
        }
    }
}
