﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Service : RegistryObject
    {
        [XmlElement("ServiceBinding")]
        public List<ServiceBinding> ServiceBindings { get; set; }
    }
}
