using System;
using System.Collections.Concurrent;

namespace XdsKit
{
    public class UriEnumeration : IEquatable<UriEnumeration>
    {
        // MH this prevents a URI from being shared by two UriEnumeration types (e.g. AssociationType and ErrorSeverity)
        // This should be ok because a URI is a namespace, but consider better options to namespace members
        private readonly static ConcurrentDictionary<string, UriEnumeration> Members = new ConcurrentDictionary<string, UriEnumeration>();

        public string Uri { get; set; }

        protected UriEnumeration(string uri)
        {
            if (Members.ContainsKey(uri)) throw new Exception(string.Format("The uri {0} is already registered", uri));

            Members[uri] = this;
            Uri = uri;
        }

        public override bool Equals(object item)
        {
            if (item == null) return false;

            var uri = item as UriEnumeration;
            if (uri != null) return Equals(uri);

            var uriValue = item as string;
            if (!string.IsNullOrEmpty(uriValue)) return (this == Parse(uriValue));

            return false;
        }

        public bool Equals(UriEnumeration other)
        {
            return other != null &&
                   ((string.IsNullOrEmpty(Uri) && string.IsNullOrEmpty(other.Uri)) ||
                    Uri.Equals(other.Uri, StringComparison.OrdinalIgnoreCase));
        }

        public override int GetHashCode()
        {
            return Uri.GetHashCode();
        }

        public override string ToString()
        {
            return Uri;
        }

        public static bool operator ==(UriEnumeration lvalue, UriEnumeration rvalue)
        {
            if ((object)lvalue == null || (object)rvalue == null) return ((object)lvalue == null && (object)rvalue == null);

            return lvalue.Equals(rvalue);
        }

        public static bool operator !=(UriEnumeration lvalue, UriEnumeration rvalue)
        {
            return !(lvalue == rvalue);
        }


        public static explicit operator string(UriEnumeration value)
        {
            return value.Uri;
        }

        public static UriEnumeration Parse(string value)
        {
            UriEnumeration result;
            return Members.TryGetValue(value, out result) ? result : null;
        }
    }
}
