using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XdsKit.Oasis.RegRep
{
    public class ErrorSeverity : UriEnumeration
    {
        protected ErrorSeverity(string uri)
            : base(uri)
        { }

        public static ErrorSeverity Error =
            new ErrorSeverity("urn:oasis:names:tc:ebxml-regrep:ErrorSeverityType:Error");

        public static ErrorSeverity Warning =
            new ErrorSeverity("urn:oasis:names:tc:ebxml-regrep:ErrorSeverityType:Warning");
    }
}
