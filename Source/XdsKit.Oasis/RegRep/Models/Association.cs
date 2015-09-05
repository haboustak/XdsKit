using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class Association : RegistryObject
    {
        private AssociationType _associationType;

        [XmlAttribute("associationType", DataType = "anyURI")]
        public string AssociationTypeValue { get; set; }

        [XmlIgnore]
        public AssociationType AssociationType
        {
            get { return _associationType ?? (_associationType = UriEnumeration.Parse(AssociationTypeValue) as AssociationType); }
            set
            {
                _associationType = null;
                AssociationTypeValue = value != null ? value.Uri : null;
            }
        }

        [XmlAttribute("sourceObject", DataType = "anyURI")]
        public string Source { get; set; }

        [XmlAttribute("targetObject", DataType = "anyURI")]
        public string Target { get; set; }
    }
}