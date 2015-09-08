namespace XdsKit.Xdsb
{
    public class XdsClassification : UriEnumeration
    {
        protected XdsClassification(string uri)
            : base(uri)
        { }

        public static XdsClassification SubmissionSetAuthor =
            new XdsClassification("urn:uuid:a7058bb9-b4e4-4307-ba5b-e3f0ab85e12d");
        
        public static XdsClassification SubmissionSetContentTypeCode =
            new XdsClassification("urn:uuid:aa543740-bdda-424e-8c96-df4873be8500");
        
        public static XdsClassification DocumentAuthor =
            new XdsClassification("urn:uuid:93606bcf-9494-43ec-9b4e-a7748d1a838d");
        
        public static XdsClassification ClassCode =
            new XdsClassification("urn:uuid:41a5887f-8865-4c09-adf7-e362475b143a");
        
        public static XdsClassification ConfidentialityCode =
            new XdsClassification("urn:uuid:f4f85eac-e6cb-4883-b524-f2705394840f");
        
        public static XdsClassification EventCode =
            new XdsClassification("urn:uuid:2c6b8cb7-8b2a-4051-b291-b1ae6a575ef4");
        
        public static XdsClassification FormatCode =
            new XdsClassification("urn:uuid:a09d5840-386c-46f2-b5ad-9c3699a4309d");

        public static XdsClassification HealthcareFacilityTypeCode =
            new XdsClassification("urn:uuid:f33fb8ac-18af-42cc-ae0e-ed0b0bdb91e1");
        
        public static XdsClassification PracticeSettingCode =
            new XdsClassification("urn:uuid:cccf5598-8b07-4b77-a05e-ae952c785ead");
        
        public static XdsClassification DocumentTypeCode =
            new XdsClassification("urn:uuid:f0306f51-975f-434e-a61c-c59651d33983");

        public static XdsClassification FolderCode =
            new XdsClassification("urn:uuid:1ba97051-7806-41a8-a48b-8fce7af683c5");
    }
}
