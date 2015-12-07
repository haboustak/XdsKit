using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Xdsb.Models
{
    public class XdsOrganization
    {
        private readonly XON _organization;

        public XON Hl7Organization
        {
            get { return _organization; }
        }

        public string Name
        {
            get { return _organization.OrganizationName!= null ? _organization.OrganizationName.Value : null; }
            set { (_organization.OrganizationName ?? (_organization.OrganizationName = new ST())).Value = value; }
        }

        public string UniversalId
        {
            get
            {
                return _organization.AssigningAuthority != null && _organization.AssigningAuthority.UniversalId!=null
                    ? _organization.AssigningAuthority.UniversalId.Value 
                    : null;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    var assigningAuthority = (_organization.AssigningAuthority ??
                                              (_organization.AssigningAuthority = new HD()));
                    (assigningAuthority.UniversalId ?? (assigningAuthority.UniversalId = new ST())).Value = value;
                    (assigningAuthority.UniversalIdType ?? (assigningAuthority.UniversalIdType = new ID())).Value =
                        "ISO";
                }
                else
                {
                    _organization.AssigningAuthority = null;
                }
            }
        }
        public string OrganizationId
        {
            get
            {
                return _organization.OrganizationIdentifier != null ? _organization.OrganizationIdentifier.Value : null;
            }
            set { (_organization.OrganizationIdentifier ?? (_organization.OrganizationIdentifier = new ST())).Value = value; }

        }

        public XdsOrganization()
            : this(new XON())
        { }

        public XdsOrganization(XON organization)
        {
            _organization = organization;
        }

        public XdsOrganization(string organization)
        {
            _organization = DataType.Parse(new XON(), organization);
        }
    }
}
