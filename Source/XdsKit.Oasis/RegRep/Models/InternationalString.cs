using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class InternationalString
    {
        [XmlElement("LocalizedString")]
        public List<LocalizedString> LocalizedStrings { get; set; }

        public string GetValue()
        {
            return GetValue("en-US");
        }

        public string GetValue(string language)
        {
            // Get the first exact-match
            return LocalizedStrings
                .Where(s =>
                    !string.IsNullOrEmpty(s.Language) &&
                    !string.IsNullOrEmpty(language) &&
                    s.Language.Equals(language, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.Value)
                .FirstOrDefault();
        }
    }
}
