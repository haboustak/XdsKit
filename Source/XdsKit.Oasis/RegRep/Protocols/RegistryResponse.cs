﻿using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Protocols
{
    [XmlRoot(Namespace = Namespaces.Rs)]
    public class RegistryResponse
    {
        [XmlAttribute("status")]
        public ResponseStatus Status { get; set; }

        public RegistryErrorList RegistryErrors { get; set; }
    }
}