﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class ValueList
    {
        [XmlElement("Value")]
        public List<string> Values { get; set; } 
    }
}
