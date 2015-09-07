namespace XdsKit.Hl7
{
    public interface IPrimitive
    { }

    public class Primitive<T> : DataType, IPrimitive
    {
        public T Value { get; set; }

        public override string ToString()
        {
            return GetValue();
        }

        public override string GetValue()
        {
            return Value!=null ? Value.ToString() : "";
        }

        public override void SetValue(string value)
        {
            if (value == "\"\"") value = "";
            Value = value.ConvertTo<T>();
        }
    }
}
