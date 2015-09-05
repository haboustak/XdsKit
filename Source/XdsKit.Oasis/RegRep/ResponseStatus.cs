using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep
{
    public class ResponseStatus : UriEnumeration
    {
        public ResponseStatus(string uri)
            : base(uri)
        { }
        
        public static ResponseStatus Success = new ResponseStatus("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:Success");
        
        public static ResponseStatus PartialSuccess = new ResponseStatus("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:PartialSuccess");

        public static ResponseStatus Failure = new ResponseStatus("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:Failure");
    }
}