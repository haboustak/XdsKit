using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XdsKit.Oasis.RegRep
{
    public enum ErrorSeverity
    {
        Unspecified,

        Unknown,

        [Description("urn:oasis:names:tc:ebxml-regrep:ErrorSeverityType:Error")]
        Error,

        [Description("urn:oasis:names:tc:ebxml-regrep:ErrorSeverityType:Warning")]
        Warning
    }
}
