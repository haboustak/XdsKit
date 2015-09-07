using System;

namespace XdsKit.Hl7.Datatypes
{
    public class TM : Primitive<string>
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int? Second { get; set; }
        public int? Millisecond { get; set; }
        public int? TenThousandths { get; set; }
        public int? OffsetHours { get; set; }
        public int? OffsetMinutes { get; set; }

        public int Precision { get; set; }

        public TM()
        { }

        public TM(int hour, int minute,
            int? second = null, int? millisecond = null, int? tenThousandths = null,
            int? offsetHours = null, int? offsetMinutes=null)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
            TenThousandths = tenThousandths;
            OffsetHours = offsetHours;
            OffsetMinutes = offsetMinutes;

            int tenths = (millisecond ?? 0) / 100;
            int hundreths = ((millisecond ?? 0) % 100) / 10;
            int thousandths = ((millisecond ?? 0) % 10);
            Precision = 4;
            if (tenThousandths != null) Precision = 11;
            else if (thousandths>0) Precision = 10;
            else if (hundreths > 0) Precision = 9;
            else if (tenths>0) Precision = 8;
            else if (second != null) Precision = 6;

            var date = new DateTime(2015, 1, 1, hour, minute, second ?? 0, millisecond ?? 0);
            Value = (date.ToString("HHmmss.fff")
                     + (TenThousandths != null ? TenThousandths.Value.ToString("0") : "")
                ).Substring(0, Precision) + TimeZoneOffset();
        }


        private string TimeZoneOffset()
        {
            if (OffsetHours == null) return "";

            return (OffsetHours > 0 ? "+" : "-")
                + Math.Abs(OffsetHours.Value).ToString().PadLeft(2, '0')
                + Math.Abs(OffsetMinutes??0).ToString().PadLeft(2, '0');
        }

        public override void SetValue(string value)
        {
            base.SetValue(value);
            if (string.IsNullOrEmpty(value)) return;

            string[] parts = value.Split(new[] {'+', '-'});
            Precision = parts[0].Length;
            Hour = parts[0].Substring(0, 2).ConvertTo<int>();
            Minute = parts[0].Substring(2, 2).ConvertTo<int>();
            Second = (Precision>4) ? parts[0].Substring(4, 2).ConvertTo<int?>() : null;
            Millisecond = (Precision > 6) ? value.Substring(7, Math.Min(Precision - 7, 3)).PadRight(3, '0').ConvertTo<int?>() : null;
            TenThousandths = (Precision > 10) ? value.Substring(10, 1).ConvertTo<int?>() : null;

            if (parts.Length > 1)
            {
                OffsetHours = parts[1].Substring(0, 2).ConvertTo<int?>();
                OffsetMinutes = parts[1].Substring(2, 2).ConvertTo<int?>();
            }
        }
    }
}
