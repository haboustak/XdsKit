using System;

namespace XdsKit
{
    public static partial class StringExtensions
    {
        public static bool Specified(this string value, string expectedDefault)
        {
            return !(string.IsNullOrEmpty(value)) &&
                !value.Equals(expectedDefault, StringComparison.OrdinalIgnoreCase);
        }
    }
}
