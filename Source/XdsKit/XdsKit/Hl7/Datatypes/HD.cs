namespace XdsKit.Hl7.Datatypes
{
    public class HD : DataType
    {
        public IS NamespaceId { get; set; }

        public ST UniversalId { get; set; }

        public ID UniversalIdType { get; set; }
    }
}
