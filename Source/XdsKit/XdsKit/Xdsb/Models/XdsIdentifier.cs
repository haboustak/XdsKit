using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Xdsb.Models
{
    public class XdsIdentifier
    {
        protected readonly CX _identifier;

        public CX Hl7Identifier
        {
            get { return _identifier; }
        }

        public string Id
        {
            get { return _identifier.IdNumber != null ? _identifier.IdNumber.Value : null; }
            set { _identifier.IdNumber = (value != null) ? new ST {Value = value} : null; }
        }

        public string UniversalId
        {
            get
            {
                return _identifier.AssigningAuthority != null && _identifier.AssigningAuthority.UniversalId != null
                    ? _identifier.AssigningAuthority.UniversalId.Value
                    : null;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _identifier.AssigningAuthority = null;
                }
                else
                {
                    var assigningAuthority = (_identifier.AssigningAuthority ??
                                              (_identifier.AssigningAuthority = new HD()));
                    (assigningAuthority.UniversalId ?? (assigningAuthority.UniversalId = new ST())).Value = value;
                    (assigningAuthority.UniversalIdType ?? (assigningAuthority.UniversalIdType = new ID())).Value = "ISO";
                }
            }
        }

        public XdsIdentifier()
            : this(new CX())
        { }

        public XdsIdentifier(CX id)
        {
            _identifier = id;
        }

        public XdsIdentifier(string id)
        {
            _identifier = DataType.Parse(new CX(), id);
        }

        public override string ToString()
        {
            return Hl7Identifier == null ? "" : Hl7Identifier.Encode();
        }
    }
}
