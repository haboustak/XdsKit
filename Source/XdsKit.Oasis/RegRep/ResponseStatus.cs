using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep
{
    public enum ResponseStatus
    {
        Unspecified,

        Unknown,
        
        [Description("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:Success")]
        Success,
        
        [Description("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:PartialSuccess")]
        PartialSuccess,
        
        [Description("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:Failure")]
        Failure
    }
}