using XdsKit.Hl7.Datatypes;


namespace XdsKit.Xdsb.Models
{
    public class XdsReferenceIdentifier : XdsIdentifier
    {
        public string IdType
        {
            get { return _identifier.IdentifierTypeCode != null ? _identifier.IdentifierTypeCode.Value : null; }
            set { _identifier.IdentifierTypeCode = (value != null) ? new ID { Value = value } : null; }
        }

        public string HomeCommunityId
        {
            get
            {
                return _identifier.AssigningFacility != null && _identifier.AssigningFacility.UniversalId != null
                    ? _identifier.AssigningFacility.UniversalId.Value
                    : null;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _identifier.AssigningFacility = null;
                }
                else
                {
                    var homeCommunity = (_identifier.AssigningFacility ??
                                              (_identifier.AssigningFacility = new HD()));
                    (homeCommunity.UniversalId ?? (homeCommunity.UniversalId = new ST())).Value = value;
                    (homeCommunity.UniversalIdType ?? (homeCommunity.UniversalIdType = new ID())).Value = "ISO";
                }
            }
        }
    }
}
