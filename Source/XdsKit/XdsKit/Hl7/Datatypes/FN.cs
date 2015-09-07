namespace XdsKit.Hl7.Datatypes
{
    public class FN : DataType
    {
        public ST Surname { get; set; }

        public ST OwnSurnamePrefix { get; set; }

        public ST OwnSurname { get; set; }

        public ST SurnamePrefixFromPartnerSpouse { get; set; }

        public ST SurnameFromPartnerSpouse { get; set; }
    }
}
