using XdsKit.Hl7.Datatypes;

namespace XdsKit.Xdsb.Models
{
    public class IntendedRecipient
    {
        public XdsPerson Person { get; set; }

        public XdsOrganization Organization { get; set; }
    }
}
