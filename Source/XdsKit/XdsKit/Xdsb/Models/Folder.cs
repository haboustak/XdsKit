using System;
using System.Collections.Generic;
using System.Linq;
using XdsKit.Hl7.Datatypes;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Xdsb.Models
{
    public class Folder : XdsEntry<RegistryPackage>
    {
        private DTM _hl7LastUpdateTime;
        private DateTimeOffset? _lastUpdateTime;
        private readonly DateTimePrecision _lastUpdateTimePrecision;

        public StatusType AvailabilityStatus { get; set; }

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

        public bool LimitedMetadata { get; set; }

        public Folder(DateTimePrecision precision = DateTimePrecision.Second)
        {
            _lastUpdateTimePrecision = precision;
            LimitedMetadata = false;
        }

        public override RegistryPackage ToRegistryObject()
        {
            var folder = new RegistryPackage
            {
                Id = EntryUuid,
                Home  = HomeCommunityId,
                Status = AvailabilityStatus,
                Description = XmlUtil.LocalString(Comments),
                Name = XmlUtil.LocalString(Title)
            };
            folder.Classifications.Add(new Classification
            {
                ClassificationScheme = XdsClassification.Folder,
                ClassifiedObject = EntryUuid,
            });

            if (Codes != null && Codes.Any())
            {
                Codes.ForEach(fc => folder.Classifications.Add(new Classification
                {
                    ClassificationScheme = XdsClassification.FolderCode,
                    ClassifiedObject = EntryUuid,
                    Name = XmlUtil.LocalString(fc.DisplayName),
                    NodeRepresentation = fc.Value,
                    Slots = new List<Slot>
                    {
                        new Slot
                        {
                            Name = "codingScheme",
                            Values = new List<string>
                            {
                                fc.CodeSystemId
                            }
                        }
                    }
                }));
            }
            if (!string.IsNullOrEmpty(UniqueId))
            {
                folder.ExternalIdentifiers.Add(new ExternalIdentifier
                {
                    IdentificationScheme = XdsIdentification.FolderUniqueId,
                    RegistryObject = EntryUuid,
                    Name = XmlUtil.LocalString("XDSFolder.uniqueId"),
                    Value = UniqueId
                });
            }
            string patientId = PatientId != null ? PatientId.ToString() : "";
            if (!string.IsNullOrEmpty(patientId))
            {
                folder.ExternalIdentifiers.Add(new ExternalIdentifier
                {
                    IdentificationScheme = XdsIdentification.FolderPatientId,
                    RegistryObject = EntryUuid,
                    Name = XmlUtil.LocalString("XDSFolder.patientId"),
                    Value = patientId
                });
            }
            if (LastUpdateTime != null)
            {
                folder.Slots.Add(new Slot
                {
                    Name = "lastUpdateTime",
                    Values = new List<string>
                    {
                        _hl7LastUpdateTime.Encode()
                    }
                });
            }
            if (LimitedMetadata)
            {
                folder.Classifications.Add(new Classification
                {
                    ClassificationScheme = XdsClassification.FolderLimitedMetadata,
                    ClassifiedObject = EntryUuid
                });
            }
            return folder;
        }
    }
}
