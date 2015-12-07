using System.Collections.Generic;
using System.Linq;
using XdsKit.Hl7.Datatypes;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Xdsb.Models
{
    public class Author
    {
        public XdsPerson Person { get; set; }

        public List<XdsOrganization> Institution { get; set; }
        
        public List<string> Role { get; set; }

        public List<string> Specialty { get; set; }

        // Telecom??

        public Classification ToClassification(string scheme, string parent)
        {
            var authorAttribute = new Classification
            {
                ClassificationScheme = scheme,
                ClassifiedObject = parent,
                ObjectType = ObjectType.Classification
            };

            if (Person != null)
            {
                authorAttribute.Slots.Add(new Slot
                {
                    Name = "authorPerson",
                    Values = new List<string> { Person.Hl7Person.Encode() }
                });
            }

            if (Institution != null && Institution.Any())
            {
                authorAttribute.Slots.Add(new Slot
                {
                    Name = "authorInstitution",
                    Values = Institution.Select(i => i.Hl7Organization.Encode()).ToList()
                });
            }

            if (Role!=null && Role.Any(r => !string.IsNullOrEmpty(r)))
            {
                authorAttribute.Slots.Add(new Slot
                {
                    Name = "authorRole",
                    Values = Role.Where(r => !string.IsNullOrEmpty(r)).ToList()
                });
            }

            if (Specialty != null && Specialty.Any(s => !string.IsNullOrEmpty(s)))
            {
                authorAttribute.Slots.Add(new Slot
                {
                    Name = "authorSpecialty",
                    Values = Specialty.Where(s => !string.IsNullOrEmpty(s)).ToList()
                });
            }
            return authorAttribute;
        }
    }
}
