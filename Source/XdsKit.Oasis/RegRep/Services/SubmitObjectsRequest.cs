using System;
using System.Linq;
using System.Xml.Serialization;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Services
{
    [XmlType("SubmitObjectsRequest", Namespace = Namespaces.Lcm)]
    public class SubmitObjectsRequest
    {
        [XmlElement("RegistryObjectList", Namespace = Namespaces.Rim)]
        public RegistryObjectList RegistryObjects { get; set; }

        public ExtrinsicObject ExtrinsicObject(string id)
        {
            return string.IsNullOrEmpty(id) 
                ? null 
                : RegistryObjects.ExtrinsicObjects.FirstOrDefault(o => o.Id!=null && o.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }
    }
}