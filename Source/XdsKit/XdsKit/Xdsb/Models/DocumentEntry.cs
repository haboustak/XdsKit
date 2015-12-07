using System;
using System.Collections.Generic;
using System.Linq;
using XdsKit.Hl7.Datatypes;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Xdsb.Models
{
    public class DocumentEntry : XdsEntry<ExtrinsicObject>
    {
        private DTM _hl7CreationTime, _hl7ServiceStartTime, _hl7ServiceStopTime;
        private DateTimeOffset? _creationTime, _serviceStartTime, _serviceStopTime;
        private readonly DateTimePrecision _creationTimePrecision, _serviceStartTimePrecision, _serviceStopTimePrecision;

        public Author Author { get; set; }

        public string AvailabilityStatus { get; set; }

        public ClassCode Class { get; set; }

        public List<ConfidentialityCode> Confidentiality { get; set; }

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

        public bool LimitedMetadata { get; set; }

        public string MimeType { get; set; }

        public string DocumentEntryType { get; set; }

        public XdsIdentifier PatientId { get; set; }

        public PracticeSettingCode PracticeSetting { get; set; }

        public List<XdsReferenceIdentifier> ReferenceIds { get; set; }

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

        public int? Size { get; set; }

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

            LimitedMetadata = false;
        }

        public override ExtrinsicObject ToRegistryObject()
        {
            var document = new ExtrinsicObject
            {
                Id = EntryUuid,
                Home = HomeCommunityId,
                Status = AvailabilityStatus,
                Description = XmlUtil.LocalString(Comments),
                Name = XmlUtil.LocalString(Title),
                MimeType = MimeType,
                ObjectType = DocumentEntryType
            };
            document.Classifications.Add(new Classification
            {
                ClassificationScheme = XdsClassification.Document,
                ClassifiedObject = EntryUuid,
            });

            if (Author != null)
            {
                var authorAttribute = Author.ToClassification(XdsClassification.DocumentAuthor, EntryUuid);
                document.Classifications.Add(authorAttribute);
            }
            if (Class != null && !string.IsNullOrEmpty(Class.Value))
                document.Classifications.Add(Class.ToClassification(EntryUuid));

            if (Confidentiality != null && Confidentiality.Any(c => !string.IsNullOrEmpty(c.Value)))
            {
                document.Classifications.AddRange(
                    Confidentiality.Select(c => c.ToClassification(EntryUuid)));
            }
            if (CreationTime != null)
                document.Slots.Add(XmlUtil.SingleSlot("creationTime", _hl7CreationTime.Encode()));

            if (EventCodes != null && EventCodes.Any(fc => !string.IsNullOrEmpty(fc.Value)))
                document.Classifications.AddRange(EventCodes.Select(fc => fc.ToClassification(EntryUuid)));
            
            if (Format != null && !string.IsNullOrEmpty(Format.Value))
                document.Classifications.Add(Format.ToClassification(EntryUuid));

            if (!string.IsNullOrEmpty(Hash))
                document.Slots.Add(XmlUtil.SingleSlot("hash", Hash));

            if (HealthCareFacilityType != null && !string.IsNullOrEmpty(HealthCareFacilityType.Value))
                document.Classifications.Add(HealthCareFacilityType.ToClassification(EntryUuid));

            if (!string.IsNullOrEmpty(LanguageCode))
                document.Slots.Add(XmlUtil.SingleSlot("languageCode", LanguageCode));
            
            if (LegalAuthenticator != null)
                document.Slots.Add(XmlUtil.SingleSlot("legalAuthenticator", LegalAuthenticator.Hl7Person.Encode()));

            string patientId = PatientId != null ? PatientId.ToString() : "";
            if (!string.IsNullOrEmpty(patientId))
            {
                document.ExternalIdentifiers.Add(new ExternalIdentifier
                {
                    IdentificationScheme = XdsIdentification.DocumentPatientId,
                    RegistryObject = EntryUuid,
                    Name = XmlUtil.LocalString("XDSFolder.patientId"),
                    Value = patientId
                });
            }

            if (PracticeSetting != null && !string.IsNullOrEmpty(PracticeSetting.Value))
                document.Classifications.Add(PracticeSetting.ToClassification(EntryUuid));

            if (!string.IsNullOrEmpty(RepositoryUniqueId))
                document.Slots.Add(XmlUtil.SingleSlot("repositoryUniqueId", RepositoryUniqueId));

            if (ServiceStartTime != null)
                document.Slots.Add(XmlUtil.SingleSlot("serviceStartTime", _hl7ServiceStartTime.Encode()));

            if (ServiceStopTime != null)
                document.Slots.Add(XmlUtil.SingleSlot("serviceStopTime", _hl7ServiceStopTime.Encode()));

            if (Size != null)
                document.Slots.Add(XmlUtil.SingleSlot("size", Size.Value.ToString()));

            if (SourcePatientId != null)
                document.Slots.Add(XmlUtil.SingleSlot("sourcePatientId", SourcePatientId.Hl7Identifier.Encode()));

            if (SourcePatientInfo != null && SourcePatientInfo.Any())
                document.Slots.Add(new Slot
                {
                    Name = "sourcePatientInfo",
                    Values = SourcePatientInfo
                });

            if (Type != null)
                document.Classifications.Add(Type.ToClassification(EntryUuid));

            if (!string.IsNullOrEmpty(Uri))
                document.Slots.Add(XmlUtil.SingleSlot("URI", Uri));

            if (!string.IsNullOrEmpty(UniqueId))
            {
                document.ExternalIdentifiers.Add(new ExternalIdentifier
                {
                    IdentificationScheme = XdsIdentification.DocumentUniqueId,
                    RegistryObject = EntryUuid,
                    Name = XmlUtil.LocalString("XDSFolder.uniqueId"),
                    Value = UniqueId
                });
            }
            if (ReferenceIds != null && ReferenceIds.Any())
            {
                document.Slots.Add(new Slot
                {
                    Name = "urn:ihe:iti:xds:2013:referenceIdList",
                    Values = ReferenceIds.Select(id => id.Hl7Identifier.Encode()).ToList()
                });
            }
            if (LimitedMetadata)
            {
                document.Classifications.Add(new Classification
                {
                    ClassificationScheme = XdsClassification.DocumentLimitedMetadata,
                    ClassifiedObject = EntryUuid
                });
            }

            return document;
        }
    }
}
