using System.Collections.Generic;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep
{
    public static class XmlUtil
    {
        public static InternationalString LocalString(string value, string charset="UTF-8", string language = "en-US")
        {
            return string.IsNullOrEmpty(value)
                ? null
                : new InternationalString
                {
                    LocalizedStrings = new List<LocalizedString>
                    {
                        new LocalizedString
                        {
                            Value = value,
                            Language = language,
                            Charset = charset
                        }
                    }
                };
        }

        public static Slot SingleSlot(string name, string value)
        {
            return new Slot
            {
                Name = name,
                Values = new List<string> {value}
            };
        }
    }
}
