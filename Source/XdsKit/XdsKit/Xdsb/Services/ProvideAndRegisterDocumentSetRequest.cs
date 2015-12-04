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
            Documents = submission.Documents.Select(d => new XdsDocument
            {
                Id = d.EntryUuid,
                Content = d.Content
            }).ToList();
        }

        private RegistryObjectList BuildMetadata(SubmissionSet submission)
        {
            var list = new RegistryObjectList();
            list.RegistryPackages.Add(submission.ToRegistryObject());
            submission.Folders.ForEach(f => list.RegistryPackages.Add(f.ToRegistryObject()));
            submission.Documents.ForEach(d => list.ExtrinsicObjects.Add(d.ToRegistryObject()));

            return list;
        }
    }
}
