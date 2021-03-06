﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class NotifyAction : Action
    {
        [XmlIgnore]
        public const string NotifcationOptionDefault = "urn:oasis:names:tc:ebxml-regrep:NotificationOptionType:ObjectRefs";

        [XmlAttribute("notificationOption", DataType = "anyURI"), DefaultValue(NotifcationOptionDefault)]
        public string NotificationOption { get; set; }

        [XmlIgnore]
        public bool NotificationOptionSpecified
        {
            get { return NotificationOption.Specified(NotifcationOptionDefault); }
        }

        [XmlAttribute("endPoint", DataType = "anyURI")]
        public string Endpoint { get; set; }

        public NotifyAction()
        {
            NotificationOption = "urn:oasis:names:tc:ebxml-regrep:NotificationOptionType:ObjectRefs";
        }
    }
}
