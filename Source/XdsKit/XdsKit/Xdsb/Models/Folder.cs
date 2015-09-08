using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XdsKit.Hl7.Datatypes;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Xdsb.Models
{
    public class Folder : XdsEntry
    {
        private DTM _hl7LastUpdateTime;
        private DateTimeOffset? _lastUpdateTime;
        private readonly DateTimePrecision _lastUpdateTimePrecision;

        public string AvailabilityStatus { get; set; }

        public List<FolderCode> Codes { get; set; }

        public DateTimeOffset? LastUpdateTime
        {
            get
            {
                return (_hl7LastUpdateTime != null && _hl7LastUpdateTime.DateTimeValue.HasValue)
                    ? (_lastUpdateTime ?? (_lastUpdateTime = _hl7LastUpdateTime.DateTimeValue))
                    : null;
            }
            set
            {
                _lastUpdateTime = value;
                _hl7LastUpdateTime = (value != null) ? _lastUpdateTime.Value.AsDTM(_lastUpdateTimePrecision) : null;
            }
        }

        public XdsIdentifier PatientId { get; set; }

        public List<DocumentEntry> Documents { get; set; }
        
        public Folder(DateTimePrecision precision = DateTimePrecision.Second)
        {
            _lastUpdateTimePrecision = precision;
        }

        public RegistryPackage ToXml()
        {
            var package = new RegistryPackage();

            return package;
        }
    }
}
