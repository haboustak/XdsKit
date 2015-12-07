using System;

namespace XdsKit.Hl7.Datatypes
{
    public class DT : Primitive<string>
    {
        public int Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }

        public int Precision { get; set; }
        
        public DT()
        { }

        public DT(int year, int? month = null, int? day = null)
        {
            Year = year;
            Month = month;
            Day = day;
            
            Precision = 4;
            if (day != null) Precision = 8;
            else if (month != null) Precision = 6;
            
            var date = new DateTime(year, month ?? 1, day ?? 1);
            Value = date.ToString("yyyyMMdd").Substring(0, Precision);
        }

        public override void SetValue(string value)
        {
            base.SetValue(value);
            if (string.IsNullOrEmpty(value)) return;

            Precision = value.Length;
            Year = value.Substring(0, 4).ConvertTo<int>();
            Month = (Precision > 4) ? value.Substring(4, 2).ConvertTo<int?>() : null;
            Day = (Precision > 6) ? value.Substring(6, 2).ConvertTo<int?>() : null;
        }
    }
}
