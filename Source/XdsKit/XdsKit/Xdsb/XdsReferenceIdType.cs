namespace XdsKit.Xdsb
{
    public class XdsReferenceIdType : UriEnumeration
    {
        protected XdsReferenceIdType(string uri)
            : base(uri)
        { }

        public static XdsReferenceIdType UniqueId =
            new XdsReferenceIdType("urn:ihe:iti:xds:2013:uniqueId");

        public static XdsReferenceIdType Accession =
            new XdsReferenceIdType("urn:ihe:iti:xds:2013:accession");

        public static XdsReferenceIdType Referral =
            new XdsReferenceIdType("urn:ihe:iti:xds:2013:referral");

        public static XdsReferenceIdType Order =
            new XdsReferenceIdType("urn:ihe:iti:xds:2013:order");

        public static XdsReferenceIdType WorkflowId =
            new XdsReferenceIdType("urn:ihe:iti:xds:2013:workflowId");
    }
}
