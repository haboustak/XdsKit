using XdsKit.Hl7.Datatypes;

namespace XdsKit.Xdsb.Models
{
    public class Author
    {
        public XdsOrganization Institution { get; set; }

        public XdsPerson Person { get; set; }
        
        public string Role { get; set; }

        public string Specialty { get; set; }
    }
}
