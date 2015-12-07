using System;
using System.Collections.Generic;
using System.Linq;
using XdsKit.Hl7.Datatypes;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Xdsb.Models
{
    public class SubmissionSet : XdsEntry<RegistryPackage>
    {
        private DTM _hl7SubmissionTime;
        private DateTimeOffset? _submissionTime;
        private readonly DateTimePrecision _submissionTimePrecision;

        public Author Author { get; set; }

        public string AvailabilityStatus { get; set; }
        
        public ContentTypeCode ContentType { get; set; }

        public List<IntendedRecipient> IntendedRecipients { get; set; }

        public bool LimitedMetadata { get; set; }

        public XdsIdentifier PatientId { get; set; }
        
        public string SourceId { get; set; }

        public DateTimeOffset? SubmissionTime
        {
            get
            {
                return (_hl7SubmissionTime != null && _hl7SubmissionTime.DateTimeValue.HasValue)
                    ? (_submissionTime ?? (_submissionTime = _hl7SubmissionTime.DateTimeValue))
                    : null;
            }
            set
            {
                _submissionTime = value;
                _hl7SubmissionTime = (value != null) ? _submissionTime.Value.AsDTM(_submissionTimePrecision) : null;
            }
        }

        public List<DocumentEntry> Documents { get; set; }

        public List<Folder> Folders { get; set; }


        public SubmissionSet(DateTimePrecision precision = DateTimePrecision.Second)
        {
            _submissionTimePrecision = precision;

            LimitedMetadata = false;
        }

        public override RegistryPackage ToRegistryObject()
        {
            var submission = new RegistryPackage
            {
                Id = EntryUuid,
                Home = HomeCommunityId,
                Status = AvailabilityStatus,
                Description = XmlUtil.LocalString(Comments),
                Name = XmlUtil.LocalString(Title)
            };
            submission.Classifications.Add(new Classification
            {
                ClassificationScheme = XdsClassification.SubmissionSet,
                ClassifiedObject = EntryUuid,
            });

            if (Author != null)
            {
                var authorAttribute = Author.ToClassification(XdsClassification.SubmissionSetAuthor, EntryUuid);
                submission.Classifications.Add(authorAttribute);
            }

            if (ContentType != null)
                submission.Classifications.Add(ContentType.ToClassification(EntryUuid));

            if (IntendedRecipients != null && IntendedRecipients.Any())
            {
                submission.Slots.Add(new Slot
                {
                    Name = "intendedRecipient",
                    Values = IntendedRecipients.Select(r => r.Encode()).ToList()
                });
            }

            string patientId = PatientId != null ? PatientId.ToString() : "";
            if (!string.IsNullOrEmpty(patientId))
            {
                submission.ExternalIdentifiers.Add(new ExternalIdentifier
                {
                    IdentificationScheme = XdsIdentification.SubmissionSetPatientId,
                    RegistryObject = EntryUuid,
                    Name = XmlUtil.LocalString("XDSSubmissionSet.patientId"),
                    Value = patientId
                });
            }

            if (!string.IsNullOrEmpty(SourceId))
            {
                submission.ExternalIdentifiers.Add(new ExternalIdentifier
                {
                    IdentificationScheme = XdsIdentification.SubmissionSetSourceId,
                    RegistryObject = EntryUuid,
                    Name = XmlUtil.LocalString("XDSSubmissionSet.sourceId"),
                    Value = SourceId
                });
            }

            if (SubmissionTime != null)
                submission.Slots.Add(XmlUtil.SingleSlot("submissionTime", _hl7SubmissionTime.Encode()));

            if (LimitedMetadata)
            {
                submission.Classifications.Add(new Classification
                {
                    ClassificationScheme = XdsClassification.SubmissionLimitedMetadata,
                    ClassifiedObject = EntryUuid
                });
            }

            return submission;
        }
    }
}
