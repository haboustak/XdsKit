using System;
using System.Collections.Generic;

using XdsKit.Hl7.Datatypes;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Xdsb.Models
{
    public class SubmissionSet : XdsEntry
    {
        private DTM _hl7Date;
        private DateTimeOffset? _submissionTime;
        private readonly DateTimePrecision _submissionTimePrecision;

        public Author Author { get; set; }

        public string AvailabilityStatus { get; set; }
        
        public ContentTypeCode ContentType { get; set; }

        public IntendedRecipient IntendedRecipient { get; set; }

        public XdsIdentifier PatientId { get; set; }
        
        public string SourceId { get; set; }

        public DateTimeOffset? SubmissionTime
        {
            get { return (_hl7Date != null && _hl7Date.DateTimeValue.HasValue)
                ? (_submissionTime ?? (_submissionTime = _hl7Date.DateTimeValue))
                : null; 
            }
            set
            {
                _submissionTime = value;
                _hl7Date = (value != null) ? _submissionTime.Value.AsDTM(_submissionTimePrecision) : null;
            }
        }

        public List<DocumentEntry> Documents { get; set; }

        public List<Folder> Folders { get; set; }


        public SubmissionSet(DateTimePrecision precision = DateTimePrecision.Second)
        {
            _submissionTimePrecision = precision;
        }

        public void SetSubmissionTime(DateTimeOffset date, DateTimePrecision precision, int? tenHundrethSeconds)
        {
            _submissionTime = date;
            _hl7Date = date.AsDTM(precision, tenHundrethSeconds);
        }

    }
}
