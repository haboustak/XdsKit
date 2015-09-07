namespace XdsKit.Hl7.Datatypes
{
    public class CWE : DataType
    {
        public ST Identifier { get; set; }

        public ST Text { get; set; }

        public ID NameofCodingSystem { get; set; }

        public ST AlternateIdentifier { get; set; }

        public ST AlternateText { get; set; }

        public ID NameofAlternateCodingSystem { get; set; }

        public ST CodingSystemVersionId { get; set; }

        public ST AlternateCodingSystemVersionId { get; set; }

        public ST OriginalText { get; set; }
    }
}
