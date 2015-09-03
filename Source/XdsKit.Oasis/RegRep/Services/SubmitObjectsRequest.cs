using System;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Services
{
    [XmlRoot(Namespace = Namespaces.Lcm)]
    public class SubmitObjectsRequest
    {
        [XmlElement("RegistryObjectList", Namespace = Namespaces.Rim)]
        public RegistryObjectList RegistryObjects { get; set; }

        [XmlNamespaceDeclarations] 
        public XmlSerializerNamespaces xmlns;

        public SubmitObjectsRequest()
        {
            xmlns = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("lcm", Namespaces.Lcm) 
            });
        }

        public ExtrinsicObject ExtrinsicObject(string id)
        {
            return string.IsNullOrEmpty(id) 
                ? null 
                : RegistryObjects.ExtrinsicObjects.FirstOrDefault(o => o.Id!=null && o.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }
    }
}