using System;

namespace XdsKit.Hl7.Datatypes
{
    public class CE : DataType
    {
        public ST Identifier { get; set; }

        public ST Text { get; set; }

        public ID NameofCodingSystem { get; set; }

        public ST AlternateIdentifier1 { get; set; }

        public ST AlternateText1 { get; set; }

        public ID NameofAlternateCodingSystem1 { get; set; }

        public ST AlternateIdentifier2 { get; set; }

        public ST AlternateText2 { get; set; }

        public ID NameofAlternateCodingSystem2 { get; set; }
    }
}
