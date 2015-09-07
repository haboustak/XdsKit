namespace XdsKit.Xdsb.Models
{
    public abstract class Code
    {
        public string UniqueId { get; set; }

        public string CodeSystemId { get; set; }

        public string Value { get; set; }
        
        public string DisplayName { get; set; }
    }
}
