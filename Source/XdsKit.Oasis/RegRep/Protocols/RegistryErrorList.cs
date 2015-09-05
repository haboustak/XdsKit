using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Protocols
{
    [XmlRoot(Namespace = Namespaces.Rs)]
    public class RegistryErrorList
    {
        private ErrorSeverity _highestSeverity;

        [XmlAttribute("highestSeverity", DataType="anyURI")]
        public string HighestSeverityValue { get; set; }

        [XmlIgnore]
        public ErrorSeverity HighestSeverity
        {
            get { return _highestSeverity ?? (_highestSeverity = UriEnumeration.Parse(HighestSeverityValue) as ErrorSeverity); }
            set
            {
                _highestSeverity = null;
                HighestSeverityValue = value != null ? value.Uri : null;
            }
        }


        [XmlElement("RegistryError")]
        public List<RegistryError> Errors { get; set; }
    }
}