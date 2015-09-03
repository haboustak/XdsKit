using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Protocols
{
    [XmlRoot(Namespace = Namespaces.Rs)]
    public class RegistryError
    {
        [XmlAttribute("codeContext")]
        public string CodeContext { get; set; }

        [XmlAttribute("errorCode")]
        public string ErrorCode { get; set; }

        [XmlAttribute("location")]
        public string Location { get; set; }

        [XmlAttribute("severity")]
        public string Severity { get; set; }
    }
}