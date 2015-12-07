using System;
using System.ComponentModel;

namespace XdsKit.Hl7.Datatypes
{
    public class DTM : Primitive<string>
    {
        private DT _date;
        private TM _time;

        private DT Date
        {
            get { return _date ?? (_date = new DT()); }
        }

        private TM Time
        {
            get { return _time ?? (_time = new TM()); }
        }

        public DateTimeOffset? DateTimeValue
        {
            get
            {
                return new DateTimeOffset(Year, Month ?? 1, Day ?? 1, Hour ?? 12, Minute ?? 0, Second ?? 0, Millisecond ?? 0, new TimeSpan(OffsetHours ?? 0, OffsetMinutes ?? 0, 0));
            }
        }
        public int Year 
        { 
            get { return _date.Year; }
            set { Date.Year = value; }
        }
        public int? Month
        { 
            get { return _date.Month; }
            set { Date.Month = value; }
        }

        public int? Day
        { 
            get { return _date.Day; }
            set { Date.Day = value; }
        }
        
        public int? Hour
        { 
            get { return _time!=null ? _time.Hour : (int?)null; }
            set
            {
                if (value != null) Time.Hour = value.Value;
                else _time = null;
            }
        }
        public int? Minute
        { 
            get { return _time!=null ? _time.Minute : (int?)null; }
            set
            {
                if (value != null) Time.Minute = value.Value;
                else _time = null;
            }
        }
        public int? Second
        { 
            get { return _time!=null ? _time.Second : null; }
            set { Time.Second = value; }
        }
        public int? Millisecond
        {
            get { return _time!=null ? _time.Millisecond : null; }
            set { Time.Millisecond = value; }
        }
        public int? TenThousandths
        { 
            get { return _time!=null ? _time.TenThousandths : null; }
            set { Time.TenThousandths = value; }
        }
        public int? OffsetHours
        {
            get { return _time != null ? _time.OffsetHours : null; }
            set { Time.OffsetHours = value; }
        }
        public int? OffsetMinutes
        {
            get { return _time != null ? _time.OffsetMinutes : null; }
            set { Time.OffsetMinutes = value; }
        }

        public DTM()
        { }

        public DTM(DateTimeOffset date, DateTimePrecision precision = DateTimePrecision.Millisecond, int? tenHundrethSeconds = null)
        {
            Initialize(date.AsDT(precision), date.AsTM(precision, tenHundrethSeconds));
        }

        public DTM(DT dt, TM tm=null)
        {
            Initialize(dt, tm);
        }
        public DTM(
            int year, int? month = null, int? day = null,
            int? hour = null, int? minute = null, int? second = null, int? milliseconds = null, int? tenThousandths = null,
            int? offsetHours = null, int? offsetMinutes=null)
        {
            Initialize(
                new DT(year, month, day),
                hour != null
                ? new TM(hour.Value, minute ?? 0, second, milliseconds, tenThousandths, offsetHours, offsetMinutes)
                : null);
        }

        private void Initialize(DT date, TM time)
        {
            _date = date;
            _time = time;
            Value = _date.GetValue() + (_time != null ? _time.GetValue() : "");
        }


        public override void SetValue(string value)
        {
            base.SetValue(value);
            if (string.IsNullOrEmpty(value)) return;

            _date = new DT();
            _date.SetValue(value.Substring(0, Math.Min(value.Length, 8)));
            if (value.Length > 8)
            {
                _time = new TM();
                _time.SetValue(value.Substring(8, value.Length-8));
            }
        }
    }
}
