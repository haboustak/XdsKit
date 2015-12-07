namespace XdsKit.Hl7.Datatypes
{
    public class CX : DataType
    {
        public ST IdNumber { get; set; }

        public ST CheckDigit { get; set; }

        public ID CheckDigitScheme { get; set; }

        public HD AssigningAuthority { get; set; }

        public ID IdentifierTypeCode { get; set; }

        public HD AssigningFacility { get; set; }

        public DT EffectiveDate { get; set; }

        public DT ExpirationDate { get; set; }

        public CWE AssigningJurisdiction { get; set; }

        public CWE AssigningAgencyOrDepartment { get; set; }
    }
}
