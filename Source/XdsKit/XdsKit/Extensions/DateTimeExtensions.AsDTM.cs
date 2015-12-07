using System;
using XdsKit.Hl7.Datatypes;

namespace XdsKit
{
    public static partial class DateTimeExtensions
    {
        public static DT AsDT(
            this DateTimeOffset date,
            DateTimePrecision precision = DateTimePrecision.Day)
        {
            switch (precision)
            {
                case DateTimePrecision.Year:
                    return new DT(date.Year);
                case DateTimePrecision.Month:
                    return new DT(date.Year, date.Month);
                default:
                    return new DT(date.Year, date.Month, date.Day);
            }
        }

        public static TM AsTM(
            this DateTimeOffset date, 
            DateTimePrecision precision=DateTimePrecision.Millisecond,
            int? tenHundrethSeconds = null)
        {
            
            switch (precision)
            {
                case DateTimePrecision.Minute:
                    return new TM(date.Hour, date.Minute, null, null, null, date.Offset.Hours, date.Offset.Minutes);
                case DateTimePrecision.Second:
                    return new TM(date.Hour, date.Minute, date.Second, null, null, date.Offset.Hours, date.Offset.Minutes);
                case DateTimePrecision.Millisecond:
                    return new TM(date.Hour, date.Minute, date.Second, date.Millisecond, null, date.Offset.Hours, date.Offset.Minutes);
                case DateTimePrecision.TenHundrethSecond:
                    return new TM(date.Hour, date.Minute, date.Second, date.Millisecond, tenHundrethSeconds, date.Offset.Hours, date.Offset.Minutes);
                default:
                    return null;
            }
        }

        public static DTM AsDTM(
            this DateTimeOffset date,
            DateTimePrecision precision = DateTimePrecision.Millisecond,
            int? tenHundrethSeconds = null)
        {
            return new DTM(date, precision, tenHundrethSeconds);
        }
    }
}
