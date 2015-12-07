namespace XdsKit.Hl7.Datatypes
{
    public class XON : DataType
    {
        public ST OrganizationName { get; set; }

        public IS OrganizationNameTypeCode { get; set; } 

        public NM IdNumber { get; set; } 

        public NM CheckDigit { get; set; } 

        public ID CheckDigitScheme { get; set; } 

        public HD AssigningAuthority { get; set; } 

        public ID IdentifierTypeCode { get; set; } 

        public HD AssigningFacility { get; set; } 

        public ID NameRepresentationCode { get; set; } 

        public ST OrganizationIdentifier { get; set; } 
        
    }
}
