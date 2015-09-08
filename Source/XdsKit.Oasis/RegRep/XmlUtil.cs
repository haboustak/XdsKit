using System.Collections.Generic;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep
{
    public static class XmlUtil
    {
        public static InternationalString LocalString(string value, string charset="UTF-8", string language = "en-US")
        {
            return new InternationalString
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
    }
}
