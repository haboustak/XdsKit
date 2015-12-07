using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Xdsb.Models
{
    public class XdsPerson
    {
        private readonly XCN _person;

        public XCN Hl7Person
        {
            get { return _person; }
        }

        public string IdNumber
        {
            get { return _person.IdNumber != null ? _person.IdNumber.Value : null; }
            set { (_person.IdNumber ?? (_person.IdNumber = new ST())).Value = value; }
        }

        public string Surname
        {
            get { return (_person.FamilyName != null && _person.FamilyName.Surname != null) ? _person.FamilyName.Surname.Value : null; }
            set
            {
                var familyName = _person.FamilyName ?? (_person.FamilyName = new FN());
                familyName.Surname = value != null ? new ST {Value = value} : null; 
            }
        }

        public string OwnSurnamePrefix
        {
            get { return (_person.FamilyName != null && _person.FamilyName.OwnSurnamePrefix != null) ? _person.FamilyName.OwnSurnamePrefix.Value : null; }
            set
            {
                var familyName = _person.FamilyName ?? (_person.FamilyName = new FN());
                familyName.OwnSurnamePrefix = value != null ? new ST { Value = value } : null;
            }
        }

        public string OwnSurname
        {
            get { return (_person.FamilyName != null && _person.FamilyName.OwnSurname != null) ? _person.FamilyName.OwnSurname.Value : null; }
            set
            {
                var familyName = _person.FamilyName ?? (_person.FamilyName = new FN());
                familyName.OwnSurname = value != null ? new ST { Value = value } : null;
            }
        }

        public string GivenName
        {
            get { return _person.GivenName != null ? _person.GivenName.Value : null; }
            set { (_person.GivenName ?? (_person.GivenName = new ST())).Value = value; }
        }

        public string SecondandFurtherGivenNames
        {
            get { return _person.SecondandFurtherGivenNames != null ? _person.SecondandFurtherGivenNames.Value : null; }
            set { (_person.SecondandFurtherGivenNames ?? (_person.SecondandFurtherGivenNames = new ST())).Value = value; }
        }

        public string Suffix
        {
            get { return _person.Suffix != null ? _person.Suffix.Value : null; }
            set { (_person.Suffix ?? (_person.Suffix = new ST())).Value = value; }
        }

        public string Prefix
        {
            get { return _person.Prefix != null ? _person.Prefix.Value : null; }
            set { (_person.Prefix ?? (_person.Prefix = new ST())).Value = value; }
        }

        public string Degree
        {
            get { return _person.Degree != null ? _person.Degree.Value : null; }
            set { (_person.Degree ?? (_person.Degree = new IS())).Value = value; }
        }

        public string ProfessionalSuffix
        {
            get { return _person.ProfessionalSuffix != null ? _person.ProfessionalSuffix.Value : null; }
            set { (_person.ProfessionalSuffix ?? (_person.ProfessionalSuffix = new ST())).Value = value; }
        }

        public string UniversalId
        {
            get
            {
                return _person.AssigningAuthority != null && _person.AssigningAuthority.UniversalId != null
                    ? _person.AssigningAuthority.UniversalId.Value
                    : null;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    var assigningAuthority = (_person.AssigningAuthority ??
                                              (_person.AssigningAuthority = new HD()));
                    (assigningAuthority.UniversalId ?? (assigningAuthority.UniversalId = new ST())).Value = value;
                    (assigningAuthority.UniversalIdType ?? (assigningAuthority.UniversalIdType = new ID())).Value = "ISO";
                }
                else
                {
                    _person.AssigningAuthority = null;
                }
            }
        }
        public XdsPerson()
            : this(new XCN())
        { }

        public XdsPerson(XCN organization)
        {
            _person = organization;
        }

        public XdsPerson(string organization)
        {
            _person = DataType.Parse(new XCN(), organization);
        }
    }
}
