using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class Subscription : RegistryObject
    {
        [XmlAttribute("selector", DataType="anyURI")]
        public string Selector { get; set; }

        [XmlAttribute("startTime")]
        public DateTime StartTime { get; set; }

        [XmlIgnore]
        public bool StartTimeSpecified { get { return StartTime != default(DateTime); } }

        [XmlAttribute("endTime")]
        public DateTime EndTime { get; set; }

        [XmlIgnore]
        public bool EndTimeSpecified { get { return EndTime != default(DateTime); } }

        [XmlAttribute("notificationInterval", DataType = "duration"), DefaultValue("P1D")]
        public string NotificationIntervalValue
        {
            get { return XmlConvert.ToString(NotificationInterval); }
            set { NotificationInterval = value.AsTimeSpan("P1D"); }
        }

        [XmlElement("NotifyAction")]
        public List<NotifyAction> NotifyActions { get; set; }

        [XmlIgnore]
        public TimeSpan NotificationInterval { get; set; }

        public Subscription()
        {
            NotificationInterval = "P1D".AsTimeSpan();
        }
    }
}
