namespace XdsKit.Hl7.Datatypes
{
    public class XCN : DataType
    {
        public ST IdNumber { get; set; }

        public FN FamilyName { get; set; }

        public ST GivenName { get; set; }

        public ST SecondandFurtherGivenNames { get; set; }

        public ST Suffix { get; set; }

        public ST Prefix { get; set; }

        public IS Degree { get; set; }

        public IS SourceTable { get; set; }

        public HD AssigningAuthority { get; set; }

        public ID NameTypeCode { get; set; }

        public ST IdentifierCheckDigit { get; set; }

        public ID CheckDigitScheme { get; set; }

        public ID IdentifierTypeCode { get; set; }

        public HD AssigningFacility { get; set; }

        public ID NameRepresentationCode { get; set; }

        public CE NameContext { get; set; }

        public DR NameValidityRange { get; set; }

        public ID NameAssemblyOrder { get; set; }

        public TS EffectiveDate { get; set; }

        public TS ExpirationDate { get; set; }

        public ST ProfessionalSuffix { get; set; }

        public CWE AssigningJurisdiction { get; set; }

        public CWE AssigningAgencyOrDepartment { get; set; }
    }
}
