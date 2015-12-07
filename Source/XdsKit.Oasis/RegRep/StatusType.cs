using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XdsKit.Oasis.RegRep
{
    public class StatusType : UriEnumeration
    {
        public StatusType(string uri)
            : base(uri)
        { }

        public static StatusType Approved = new StatusType("urn:oasis:names:tc:ebxml-regrep:StatusType:Approved");

        public static StatusType Deprecated = new StatusType("urn:oasis:names:tc:ebxml-regrep:StatusType:Deprecated");

        public static StatusType Submitted = new StatusType("urn:oasis:names:tc:ebxml-regrep:StatusType:Submitted");

        public static StatusType Withdrawn = new StatusType("urn:oasis:names:tc:ebxml-regrep:StatusType:Withdrawn");

    }
}
