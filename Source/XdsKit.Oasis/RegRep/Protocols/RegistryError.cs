using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Protocols
{
    [XmlRoot(Namespace = Namespaces.Rs)]
    public class RegistryError
    {
        private ErrorSeverity _severity;

        private const string SeverityError = "urn:oasis:names:tc:ebxml-regrep:ErrorSeverityType:Error";

        [XmlAttribute("codeContext")]
        public string CodeContext { get; set; }

        [XmlAttribute("errorCode")]
        public string ErrorCode { get; set; }


        [XmlAttribute("severity", DataType="anyURI"), DefaultValue(SeverityError)]
        public string SeverityValue { get; set; }


        [XmlIgnore]
        public ErrorSeverity Severity
        {
            get { return _severity ?? (_severity = UriEnumeration.Parse(SeverityValue) as ErrorSeverity); }
            set
            {
                _severity = null;
                SeverityValue = value != null ? value.Uri : null;
            }
        }

        [XmlAttribute("location")]
        public string Location { get; set; }

        [XmlIgnore]
        public bool SeveritySpecified
        {
            get { return SeverityValue.Specified(SeverityError); } 
        }

        public RegistryError()
        {
            Severity = ErrorSeverity.Error;
        }
    }
}