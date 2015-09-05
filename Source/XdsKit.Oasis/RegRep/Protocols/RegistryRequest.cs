using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Protocols
{
    [XmlRoot(Namespace = Namespaces.Rs)]
    public class RegistryRequest
    {
        [XmlAttribute("id", DataType="anyURI")]
        public string Id { get; set; }

        [XmlAttribute("comment")]
        public string Comment { get; set; }

        [XmlArray("RequestSlotList", Namespace = Namespaces.Rim)]
        public List<Slot> Slots { get; set; }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns;

        public RegistryRequest()
        {
            xmlns = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("rs", Namespaces.Rs),
                new XmlQualifiedName("rim", Namespaces.Rim) 
            });
        }
    }
}
