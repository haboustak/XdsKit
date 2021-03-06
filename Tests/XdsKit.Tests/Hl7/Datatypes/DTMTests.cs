﻿using System;
using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class DTMTests
    {
        [Test]
        public void Should_Serialize_yyyy()
        {
            var date = new DTM(2015);
            Assert.AreEqual("2015", date.Value);
        }

        [Test]
        public void Should_Serialize_yyyyMM()
        {
            var date = new DTM(2015, 4);
            Assert.AreEqual("201504", date.Value);
        }

        [Test]
        public void Should_Serialize_yyyyMMdd()
        {
            var date = new DTM(2015, 12, 31);
            Assert.AreEqual("20151231", date.Value);
        }


        [Test]
        public void Should_Serialize_yyyyMMddHH()
        {
            var date = new DTM(2015, 6, 6, 14);
            Assert.AreEqual("201506061400", date.Value);

            date = new DTM(2015, 6, 6, 14, null, null, null, null, 3, 30);
            Assert.AreEqual("201506061400+0330", date.Value);
        }


        [Test]
        public void Should_Serialize_yyyyMMddHHmm()
        {
            var date = new DTM(2015, 8, 3, 9, 22);
            Assert.AreEqual("201508030922", date.Value);

            date = new DTM(2015, 8, 3, 9, 22, null, null, null, -2);
            Assert.AreEqual("201508030922-0200", date.Value);
        }

        [Test]
        public void Should_Serialize_yyyyMMddHHmmss()
        {
            var date = new DTM(2000, 3, 1, 11, 11, 2);
            Assert.AreEqual("20000301111102", date.Value);

            date = new DTM(2000, 3, 1, 11, 11, 2, null, null, -2, 15);
            Assert.AreEqual("20000301111102-0215", date.Value);
        }

        [Test]
        public void Should_Serialize_yyyyMMddHHmmss_s()
        {
            var date = new DTM(2000, 3, 1, 11, 11, 2, 400);
            Assert.AreEqual("20000301111102.4", date.Value);

            date = new DTM(2000, 3, 1, 11, 11, 2, 400, null, -5);
            Assert.AreEqual("20000301111102.4-0500", date.Value);
        }
        [Test]
        public void Should_Serialize_yyyyMMddHHmmss_ss()
        {
            var date = new DTM(2000, 3, 1, 11, 11, 2, 40);
            Assert.AreEqual("20000301111102.04", date.Value);
            date = new DTM(2000, 3, 1, 11, 11, 2, 240);
            Assert.AreEqual("20000301111102.24", date.Value);

            date = new DTM(2000, 3, 1, 11, 11, 2, 40, null, -5);
            Assert.AreEqual("20000301111102.04-0500", date.Value);
            date = new DTM(2000, 3, 1, 11, 11, 2, 240, null, -8);
            Assert.AreEqual("20000301111102.24-0800", date.Value);
        }

        [Test]
        public void Should_Serialize_yyyyMMddHHmmss_sss()
        {
            var date = new DTM(2000, 3, 1, 11, 11, 2, 4);
            Assert.AreEqual("20000301111102.004", date.Value);
            date = new DTM(2000, 3, 1, 11, 11, 2, 14);
            Assert.AreEqual("20000301111102.014", date.Value);
            date = new DTM(2000, 3, 1, 11, 11, 2, 104);
            Assert.AreEqual("20000301111102.104", date.Value);
            date = new DTM(2000, 3, 1, 11, 11, 2, 124);
            Assert.AreEqual("20000301111102.124", date.Value);

            date = new DTM(2000, 3, 1, 11, 11, 2, 4, null, -5);
            Assert.AreEqual("20000301111102.004-0500", date.Value);
            date = new DTM(2000, 3, 1, 11, 11, 2, 14, null, -5);
            Assert.AreEqual("20000301111102.014-0500", date.Value);
            date = new DTM(2000, 3, 1, 11, 11, 2, 104, null, -5);
            Assert.AreEqual("20000301111102.104-0500", date.Value);
            date = new DTM(2000, 3, 1, 11, 11, 2, 124, null, -5);
            Assert.AreEqual("20000301111102.124-0500", date.Value);
        }

        [Test]
        public void Should_Serialize_yyyyMMddHHmmss_ssss()
        {
            var date = new DTM(2000, 3, 1, 11, 11, 2, 364, 5);
            Assert.AreEqual("20000301111102.3645", date.Value);

            date = new DTM(2000, 3, 1, 11, 11, 2, 364, 5, 4);
            Assert.AreEqual("20000301111102.3645+0400", date.Value);
        }

        [Test]
        public void Should_Parse_yyyy()
        {
            var date = DataType.Parse(new DTM(), "2015");
            Assert.AreEqual("2015", date.Value);
            Assert.AreEqual(2015, date.Year);
            Assert.IsNull(date.Month);
            Assert.IsNull(date.Day);
            Assert.IsNull(date.Hour);
            Assert.IsNull(date.Minute);
            Assert.IsNull(date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_yyyyMM()
        {
            var date = DataType.Parse(new DTM(), "201504");
            Assert.AreEqual("201504", date.Value);
            Assert.AreEqual(2015, date.Year);
            Assert.AreEqual(4, date.Month);
            Assert.IsNull(date.Day);
            Assert.IsNull(date.Hour);
            Assert.IsNull(date.Minute);
            Assert.IsNull(date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_yyyyMMdd()
        {
            var date = DataType.Parse(new DTM(), "20151231");
            Assert.AreEqual("20151231", date.Value);
            Assert.AreEqual(2015, date.Year);
            Assert.AreEqual(12, date.Month);
            Assert.AreEqual(31, date.Day);
            Assert.IsNull(date.Hour);
            Assert.IsNull(date.Minute);
            Assert.IsNull(date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);
        }


        [Test]
        public void Should_Parse_yyyyMMddHH()
        {
            var date = DataType.Parse(new DTM(), "201506061400");
            Assert.AreEqual("201506061400", date.Value);
            Assert.AreEqual(2015, date.Year);
            Assert.AreEqual(6, date.Month);
            Assert.AreEqual(6, date.Day);
            Assert.AreEqual(14, date.Hour);
            Assert.AreEqual(00, date.Minute);
            Assert.IsNull(date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "201506061400+0330");
            Assert.AreEqual("201506061400+0330", date.Value);
            Assert.AreEqual(2015, date.Year);
            Assert.AreEqual(6, date.Month);
            Assert.AreEqual(6, date.Day);
            Assert.AreEqual(14, date.Hour);
            Assert.AreEqual(00, date.Minute);
            Assert.IsNull(date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(3, date.OffsetHours);
            Assert.AreEqual(30, date.OffsetMinutes);
        }


        [Test]
        public void Should_Parse_yyyyMMddHHmm()
        {
            var date = DataType.Parse(new DTM(), "201508030922");
            Assert.AreEqual("201508030922", date.Value);
            Assert.AreEqual(2015, date.Year);
            Assert.AreEqual(8, date.Month);
            Assert.AreEqual(3, date.Day);
            Assert.AreEqual(9, date.Hour);
            Assert.AreEqual(22, date.Minute);
            Assert.IsNull(date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "201508030922-0200");
            Assert.AreEqual("201508030922-0200", date.Value);
            Assert.AreEqual(2015, date.Year);
            Assert.AreEqual(8, date.Month);
            Assert.AreEqual(3, date.Day);
            Assert.AreEqual(9, date.Hour);
            Assert.AreEqual(22, date.Minute);
            Assert.IsNull(date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(2, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_yyyyMMddHHmmss()
        {
            var date = DataType.Parse(new DTM(), "20000301111102");
            Assert.AreEqual("20000301111102", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(02, date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102-0215");
            Assert.AreEqual("20000301111102-0215", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(02, date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(2, date.OffsetHours);
            Assert.AreEqual(15, date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_yyyyMMddHHmmss_s()
        {
            var date = DataType.Parse(new DTM(), "20000301111102.4");
            Assert.AreEqual("20000301111102.4", date.Value);

            date = DataType.Parse(new DTM(), "20000301111102.4-0500");
            Assert.AreEqual("20000301111102.4-0500", date.Value);
        }

        [Test]
        public void Should_Parse_yyyyMMddHHmmss_ss()
        {
            var date = DataType.Parse(new DTM(), "20000301111102.04");
            Assert.AreEqual("20000301111102.04", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(40, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.24");
            Assert.AreEqual("20000301111102.24", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(240, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);


            date = DataType.Parse(new DTM(), "20000301111102.04-0500");
            Assert.AreEqual("20000301111102.04-0500", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(40, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.24-0800");
            Assert.AreEqual("20000301111102.24-0800", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(240, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(8, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_yyyyMMddHHmmss_sss()
        {
            var date = DataType.Parse(new DTM(), "20000301111102.004");
            Assert.AreEqual("20000301111102.004", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(4, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.014");
            Assert.AreEqual("20000301111102.014", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(14, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.104");
            Assert.AreEqual("20000301111102.104", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(104, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.124");
            Assert.AreEqual("20000301111102.124", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(124, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.004-0500");
            Assert.AreEqual("20000301111102.004-0500", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(4, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.014-0500");
            Assert.AreEqual("20000301111102.014-0500", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(14, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.104-0500");
            Assert.AreEqual("20000301111102.104-0500", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(104, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.124-0500");
            Assert.AreEqual("20000301111102.124-0500", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(124, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_yyyyMMddHHmmss_ssss()
        {
            var date = DataType.Parse(new DTM(), "20000301111102.3645");
            Assert.AreEqual("20000301111102.3645", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(364, date.Millisecond);
            Assert.AreEqual(5, date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new DTM(), "20000301111102.3645+0400");
            Assert.AreEqual("20000301111102.3645+0400", date.Value);
            Assert.AreEqual(2000, date.Year);
            Assert.AreEqual(3, date.Month);
            Assert.AreEqual(1, date.Day);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(364, date.Millisecond);
            Assert.AreEqual(5, date.TenThousandths);
            Assert.AreEqual(4, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);
        }

        [Test]
        public void Should_Encode_DateTime_DefaultPrecision()
        {
            var date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(4, 0, 0));
            var hl7Date = new DTM(date);
            Assert.AreEqual("20150904115959.123+0400", hl7Date.Encode());

            date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(0,0,0));
            hl7Date = new DTM(date);
            Assert.AreEqual("20150904115959.123", hl7Date.Encode());
        }

        [Test]
        public void Should_Encode_DateTime_yyyy()
        {
            var date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(4, 0, 0));
            var hl7Date = new DTM(date, DateTimePrecision.Year);
            Assert.AreEqual("2015", hl7Date.Encode());

            hl7Date = new DTM(date, DateTimePrecision.Year, 7);
            Assert.AreEqual("2015", hl7Date.Encode());
        }

        [Test]
        public void Should_Encode_DateTime_Should_Encode_DateTime_yyyyMM()
        {
            var date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(4, 0, 0));
            var hl7Date = new DTM(date, DateTimePrecision.Month);
            Assert.AreEqual("201509", hl7Date.Encode());

            hl7Date = new DTM(date, DateTimePrecision.Month, 7);
            Assert.AreEqual("201509", hl7Date.Encode());
        }

        [Test]
        public void Should_Encode_DateTime_Should_Encode_DateTime_yyyyMMdd()
        {
            var date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(4, 0, 0));
            var hl7Date = new DTM(date, DateTimePrecision.Day);
            Assert.AreEqual("20150904", hl7Date.Encode());

            date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(0, 0, 0));
            hl7Date = new DTM(date, DateTimePrecision.Day, 7);
            Assert.AreEqual("20150904", hl7Date.Encode());
        }

        [Test]
        public void Should_Encode_DateTime_Should_Encode_DateTime_yyyyMMddHHmm()
        {
            var date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(4, 0, 0));
            var hl7Date = new DTM(date, DateTimePrecision.Minute);
            Assert.AreEqual("201509041159+0400", hl7Date.Encode());

            date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(0, 0, 0));
            hl7Date = new DTM(date, DateTimePrecision.Minute);
            Assert.AreEqual("201509041159", hl7Date.Encode());

            hl7Date = new DTM(date, DateTimePrecision.Minute, 7);
            Assert.AreEqual("201509041159", hl7Date.Encode());
        }

        [Test]
        public void Should_Encode_DateTime_Should_Encode_DateTime_yyyyMMddHHmmss()
        {
            var date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(4, 0, 0));
            var hl7Date = new DTM(date, DateTimePrecision.Second);
            Assert.AreEqual("20150904115959+0400", hl7Date.Encode());

            date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(0, 0, 0));
            hl7Date = new DTM(date, DateTimePrecision.Second);
            Assert.AreEqual("20150904115959", hl7Date.Encode());

            hl7Date = new DTM(date, DateTimePrecision.Second, 7);
            Assert.AreEqual("20150904115959", hl7Date.Encode());
        }

        [Test]
        public void Should_Encode_DateTime_Should_Encode_DateTime_yyyyMMddHHmmss_sss()
        {
            var date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(4, 0, 0));
            var hl7Date = new DTM(date, DateTimePrecision.Millisecond);
            Assert.AreEqual("20150904115959.123+0400", hl7Date.Encode());

            date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(0, 0, 0));
            hl7Date = new DTM(date, DateTimePrecision.Millisecond);
            Assert.AreEqual("20150904115959.123", hl7Date.Encode());

            hl7Date = new DTM(date, DateTimePrecision.Millisecond, 7);
            Assert.AreEqual("20150904115959.123", hl7Date.Encode());
        }

        [Test]
        public void Should_Encode_DateTime_Should_Encode_DateTime_yyyyMMddHHmmss_ssss()
        {
            var date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(4, 0, 0));
            var hl7Date = new DTM(date, DateTimePrecision.TenHundrethSecond);
            Assert.AreEqual("20150904115959.123+0400", hl7Date.Encode());
           
            hl7Date = new DTM(date, DateTimePrecision.TenHundrethSecond, 7);
            Assert.AreEqual("20150904115959.1237+0400", hl7Date.Encode());

            date = new DateTimeOffset(2015, 9, 4, 11, 59, 59, 123, new TimeSpan(0, 0, 0));
            hl7Date = new DTM(date, DateTimePrecision.TenHundrethSecond);
            Assert.AreEqual("20150904115959.123", hl7Date.Encode());

            hl7Date = new DTM(date, DateTimePrecision.TenHundrethSecond, 7);
            Assert.AreEqual("20150904115959.1237", hl7Date.Encode());
        }
    }
}
