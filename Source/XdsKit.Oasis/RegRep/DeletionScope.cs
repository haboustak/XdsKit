using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XdsKit.Oasis.RegRep
{
    public class DeletionScope : UriEnumeration
    {
        public DeletionScope(string uri)
            : base(uri)
        { }

        public static DeletionScope DeleteAll = new DeletionScope("urn:oasis:names:tc:ebxml-regrep:DeletionScopeType:DeleteAll");

        public static DeletionScope DeleteRepositoryItemOnly = new DeletionScope("urn:oasis:names:tc:ebxml-regrep:DeletionScopeType:DeleteRepositoryItemOnly");

    }
}
