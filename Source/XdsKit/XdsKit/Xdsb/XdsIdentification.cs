using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XdsKit.Xdsb
{
    public class XdsIdentification : UriEnumeration
    {
        protected XdsIdentification(string uri)
            : base(uri)
        { }

        public static XdsIdentification SubmissionSetPatientId = new XdsIdentification("urn:uuid:6b5aea1a-874d-4603-a4bc-96a0a7b38446");
        public static XdsIdentification SubmissionSetUniqueId = new XdsIdentification("urn:uuid:554ac39e-e3fe-47fe-b233-965d2a147832");
        public static XdsIdentification SubmissionSetSourceId = new XdsIdentification("urn:uuid:96fdda7c-d067-4183-912e-bf5ee74998a8");


        public static XdsIdentification DocumentPatientId = new XdsIdentification("urn:uuid:58a6f841-87b3-4a3e-92fd-a8ffeff98427");
        public static XdsIdentification DocumentUniqueId = new XdsIdentification("urn:uuid:2e82c1f6-a085-4c72-9da3-8640a32e42ab");

        public static XdsIdentification FolderPatientId = new XdsIdentification("urn:uuid:f64ffdf0-4b97-4e06-b79f-a52b38ec2f8a");
        public static XdsIdentification FolderUniqueId = new XdsIdentification("urn:uuid:75df8f67-9973-4fbe-a900-df66cefecc5a");
    }
}
