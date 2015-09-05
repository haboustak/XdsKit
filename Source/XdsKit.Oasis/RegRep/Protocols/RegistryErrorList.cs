using System.Collections.Generic;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Protocols
{
    [XmlRoot(Namespace = Namespaces.Rs)]
    public class RegistryErrorList
    {
        [XmlAttribute("highestSeverity", DataType="anyURI")]
        public string HighestSeverityValue { get; set; }

        [XmlIgnore]
        public ErrorSeverity HighestSeverity
        {
            get
            {
                if (string.IsNullOrEmpty(HighestSeverityValue)) return ErrorSeverity.Unspecified;
                return HighestSeverityValue.AsEnum(ErrorSeverity.Unknown);
            }
            set
            {
                if (value == ErrorSeverity.Unknown || value == ErrorSeverity.Unspecified) HighestSeverityValue = "";
                else HighestSeverityValue = value.Description();
            }
        }

        [XmlElement("RegistryError")]
        public List<RegistryError> Errors { get; set; }
    }
}