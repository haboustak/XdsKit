using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Protocols
{
    [XmlRoot(Namespace = Namespaces.Rs)]
    public class RegistryResponse
    {
        private ResponseStatus _status;

        [XmlAttribute("status", DataType="anyURI")]
        public string StatusValue { get; set; }

        [XmlIgnore]
        public ResponseStatus Status
        {
            get { return _status ?? (_status = UriEnumeration.Parse(StatusValue) as ResponseStatus); }
            set
            {
                _status = null;
                StatusValue = value != null ? value.Uri : null;
            }
        }


        [XmlAttribute("requestId", DataType = "anyURI")]
        public string RequestId { get; set; }

        [XmlArray("ResponseSlotList", Namespace = Namespaces.Rim)]
        public List<Slot> Slots { get; set; }

        [XmlElement("RegistryErrorList")]
        public RegistryErrorList RegistryErrors { get; set; }
        
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns;

        public RegistryResponse()
        {
            xmlns = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("rs", Namespaces.Rs),
                new XmlQualifiedName("rim", Namespaces.Rim) 
            });
        }
    }
}