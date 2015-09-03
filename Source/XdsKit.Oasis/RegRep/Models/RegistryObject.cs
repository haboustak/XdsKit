using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class RegistryObject : Identifiable
    {
        [XmlElement("Name")]
        public InternationalString Name { get; set; }

        [XmlElement("Description")]
        public InternationalString Description { get; set; }

        [XmlElement("VersionInfo")]
        public VersionInfo VersionInfo { get; set; }

        [XmlElement("Classification")]
        public List<Classification> Classifications { get; set; }

        [XmlElement("ExternalIdentifier")]
        public List<ExternalIdentifier> ExternalIdentifiers { get; set; }

        [XmlAttribute("lid", DataType = "anyURI")]
        public string LocalId { get; set; }

        [XmlAttribute("objectType", DataType = "anyURI")]
        public string ObjectType { get; set; }

        [XmlAttribute("status", DataType = "anyURI")]
        public string Status { get; set; }

    }
}
