using System;
using System.Collections.Generic;
using XdsKit.Hl7.Datatypes;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Xdsb.Models
{
    public class DocumentEntry : XdsEntry
    {
        private DTM _hl7CreationTime, _hl7ServiceStartTime, _hl7ServiceStopTime;
        private DateTimeOffset? _creationTime, _serviceStartTime, _serviceStopTime;
        private readonly DateTimePrecision _creationTimePrecision, _serviceStartTimePrecision, _serviceStopTimePrecision;

        public Author Author { get; set; }

        public string AvailabilityStatus { get; set; }

        public ClassCode Class { get; set; }

        public ConfidentialityCode Confidentiality { get; set; }

        public DateTimeOffset? CreationTime
        {
            get
            {
                return (_hl7CreationTime != null && _hl7CreationTime.DateTimeValue.HasValue)
                    ? (_creationTime ?? (_creationTime = _hl7CreationTime.DateTimeValue))
                    : null;
            }
            set
            {
                _creationTime = value;
                _hl7CreationTime = (value != null) ? _creationTime.Value.AsDTM(_creationTimePrecision) : null;
            }
        }

        public List<EventCode> EventCodes { get; set; }

        public FormatCode Format { get; set; }

        public string Hash { get; set; }

        public HealthcareFacilityTypeCode HealthCareFacilityType { get; set; }
        
        public string LanguageCode { get; set; }

        public XdsPerson LegalAuthenticator { get; set; }

        public string MimeType { get; set; }

        public XdsIdentifier PatientId { get; set; }

        public PracticeSettingCode PracticeSetting { get; set; }

        public string RepositoryUniqueId { get; set; }

        public DateTimeOffset? ServiceStartTime
        {
            get
            {
                return (_hl7ServiceStartTime != null && _hl7ServiceStartTime.DateTimeValue.HasValue)
                    ? (_serviceStartTime ?? (_serviceStartTime = _hl7ServiceStartTime.DateTimeValue))
                    : null;
            }
            set
            {
                _serviceStartTime = value;
                _hl7ServiceStartTime = (value != null) ? _serviceStartTime.Value.AsDTM(_serviceStartTimePrecision) : null;
            }
        }

        public DateTimeOffset? ServiceStopTime
        {
            get
            {
                return (_hl7ServiceStopTime != null && _hl7ServiceStopTime.DateTimeValue.HasValue)
                    ? (_serviceStopTime ?? (_serviceStopTime = _hl7ServiceStopTime.DateTimeValue))
                    : null;
            }
            set
            {
                _serviceStopTime = value;
                _hl7ServiceStopTime = (value != null) ? _serviceStopTime.Value.AsDTM(_serviceStopTimePrecision) : null;
            }
        }

        public int Size { get; set; }

        public XdsIdentifier SourcePatientId { get; set; }

        public List<string> SourcePatientInfo { get; set; }

        public DocumentTypeCode Type { get; set; }

        public string Uri { get; set; }

        public byte[] Content { get; set; }
        
        public DocumentEntry(
            DateTimePrecision precision = DateTimePrecision.Second)
            : this(precision, precision, precision)
        { }

        public DocumentEntry(
            DateTimePrecision creationPrecision,
            DateTimePrecision serviceStartTimePrecision = DateTimePrecision.Second,
            DateTimePrecision serviceStopTimePrecision = DateTimePrecision.Second)
        {
            _creationTimePrecision = creationPrecision;
            _serviceStartTimePrecision = serviceStartTimePrecision;
            _serviceStopTimePrecision = serviceStopTimePrecision;
        }

        public ExtrinsicObject ToXml()
        {
            var document = new ExtrinsicObject();

            return document;
        }
    }
}
