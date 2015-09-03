using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Protocols
{
    public enum ResponseStatus
    {
        [XmlEnum("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:Success")]
        Success,
        [XmlEnum("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:PartialSuccess")]
        PartialSuccess,
        [XmlEnum("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:Failure")]
        Failure
    }
}