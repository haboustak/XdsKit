using XdsKit.Hl7.Datatypes;

namespace XdsKit.Xdsb.Models
{
    public class IntendedRecipient
    {
        public XdsPerson Person { get; set; }

        public XdsOrganization Organization { get; set; }

        public override string ToString()
        {
            return Encode();
        }

        public string Encode()
        {
            return string.Format("{0}|{1}",
                Organization.Hl7Organization.Encode(),
                Person.Hl7Person.Encode());
        }
    }
}
