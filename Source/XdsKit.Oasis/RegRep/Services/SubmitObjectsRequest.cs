﻿using System.Xml.Serialization;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Services
{
    [XmlRoot(Namespace = Namespaces.Lcm)]
    public class SubmitObjectsRequest : LcmServiceRequest
    {
        [XmlElement("RegistryObjectList", Namespace = Namespaces.Rim)]
        public RegistryObjectList RegistryObjects { get; set; }
    }
}