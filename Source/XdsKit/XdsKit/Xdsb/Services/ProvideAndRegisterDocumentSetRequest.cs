using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

using XdsKit.Oasis;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Oasis.RegRep.Services;
using XdsKit.Xdsb.Models;

namespace XdsKit.Xdsb.Services
{
    [XmlRoot("ProvideAndRegisterDocumentSetRequest", Namespace = Namespaces.Xdsb)]
    public class ProvideAndRegisterDocumentSetRequest
    {
        [XmlElement("SubmitObjectsRequest", Namespace = Namespaces.Lcm)]
        public SubmitObjectsRequest SubmitObjectsRequest
        {
            get; 
            set;
        }

        [XmlElement("Document", Namespace = Namespaces.Xdsb)]
        public List<XdsDocument> Documents
        {
            get; 
            set;
        }
        
        public ProvideAndRegisterDocumentSetRequest()
        { }

        public ProvideAndRegisterDocumentSetRequest(SubmissionSet submission)
        {
            SubmitObjectsRequest = new SubmitObjectsRequest
            {
                RegistryObjects = BuildMetadata(submission)
            };
            Documents = new List<XdsDocument>();
            submission.Documents.ForEach(d => Documents.Add(new XdsDocument
            {
                Id = d.EntryUuid,
                Content = d.Content
            }));
        }

        private RegistryObjectList BuildMetadata(SubmissionSet submission)
        {
            var list = new RegistryObjectList();
            list.RegistryPackages.Add(GetSubmissionPackage(submission));
            submission.Folders.ForEach(f => list.RegistryPackages.Add(GetFolderPackage(f)));
            submission.Documents.ForEach(d => list.ExtrinsicObjects.Add(d.ToXml()));

            return list;
        }

        private RegistryPackage GetSubmissionPackage(SubmissionSet submission)
        {
            var package = new RegistryPackage
            {
                Id = submission.EntryUuid,
                Status = "Approved",
                Description = XmlUtil.LocalString(submission.Comments),

            };
            
            package.Classifications.Add(GetAuthor(submission.Author, submission.EntryUuid, XdsClassification.SubmissionSetAuthor));

            return package;
        }

        private RegistryPackage GetFolderPackage(Folder submission)
        {
            var package = new RegistryPackage();

            return package;
        }

        private ExtrinsicObject GetDocumentObject(DocumentEntry document)
        {
            var obj = new ExtrinsicObject();

            return obj;
        }

        private Classification GetAuthor(Author author, string parentObject, string classificationScheme)
        {
            var classification =  new Classification
            {
                ClassificationScheme = classificationScheme,
                ClassifiedObject = parentObject,
                Slots = new List<Slot>()
            };

            if (author.Person != null)
                classification.Slots.Add(new Slot
                {
                    Name = "authorPerson",
                    Values = new List<string> { author.Person.Hl7Person.Encode() }
                });

            if (author.Institution != null)
                classification.Slots.Add(new Slot
                {
                    Name = "authorInstitution",
                    Values = new List<string> { author.Institution.Hl7Organization.Encode() }
                });

            if (!string.IsNullOrEmpty(author.Role))
                classification.Slots.Add(new Slot
                {
                    Name = "authorRole",
                    Values = new List<string> { author.Role }
                });

            if (!string.IsNullOrEmpty(author.Specialty))
                classification.Slots.Add(new Slot
                {
                    Name = "authorSpecialty",
                    Values = new List<string> { author.Specialty }
                });

            return classification;
        }
    }
}
