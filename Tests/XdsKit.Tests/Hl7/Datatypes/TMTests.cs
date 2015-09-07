using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class TMTests
    {
        [Test]
        public void Should_Serialize_HHMM()
        {
            var date = new TM(14, 0);
            Assert.AreEqual("1400", date.Value);

            date = new TM(14, 0, null, null, null, 3, 30);
            Assert.AreEqual("1400+0330", date.Value);
        }

        [Test]
        public void Should_Serialize_HHmm()
        {
            var date = new TM(9, 22);
            Assert.AreEqual("0922", date.Value);

            date = new TM(9, 22, null, null, null, -2);
            Assert.AreEqual("0922-0200", date.Value);
        }

        [Test]
        public void Should_Serialize_HHmmss()
        {
            var date = new TM(11, 11, 2);
            Assert.AreEqual("111102", date.Value);

            date = new TM(11, 11, 2, null, null, -2, 15);
            Assert.AreEqual("111102-0215", date.Value);
        }

        [Test]
        public void Should_Serialize_HHmmss_s()
        {
            var date = new TM(11, 11, 2, 400);
            Assert.AreEqual("111102.4", date.Value);

            date = new TM(11, 11, 2, 400, null, -5);
            Assert.AreEqual("111102.4-0500", date.Value);
        }
        [Test]
        public void Should_Serialize_HHmmss_ss()
        {
            var date = new TM(11, 11, 2, 40);
            Assert.AreEqual("111102.04", date.Value);
            date = new TM(11, 11, 2, 240);
            Assert.AreEqual("111102.24", date.Value);

            date = new TM(11, 11, 2, 40, null, -5);
            Assert.AreEqual("111102.04-0500", date.Value);
            date = new TM(11, 11, 2, 240, null, -8);
            Assert.AreEqual("111102.24-0800", date.Value);
        }

        [Test]
        public void Should_Serialize_HHmmss_sss()
        {
            var date = new TM(11, 11, 2, 4);
            Assert.AreEqual("111102.004", date.Value);
            date = new TM(11, 11, 2, 14);
            Assert.AreEqual("111102.014", date.Value);
            date = new TM(11, 11, 2, 104);
            Assert.AreEqual("111102.104", date.Value);
            date = new TM(11, 11, 2, 124);
            Assert.AreEqual("111102.124", date.Value);

            date = new TM(11, 11, 2, 4, null, -5);
            Assert.AreEqual("111102.004-0500", date.Value);
            date = new TM(11, 11, 2, 14, null, -5);
            Assert.AreEqual("111102.014-0500", date.Value);
            date = new TM(11, 11, 2, 104, null, -5);
            Assert.AreEqual("111102.104-0500", date.Value);
            date = new TM(11, 11, 2, 124, null, -5);
            Assert.AreEqual("111102.124-0500", date.Value);
        }

        [Test]
        public void Should_Serialize_HHmmss_ssss()
        {
            var date = new TM(11, 11, 2, 364, 5);
            Assert.AreEqual("111102.3645", date.Value);

            date = new TM(11, 11, 2, 364, 5, 4);
            Assert.AreEqual("111102.3645+0400", date.Value);
        }

        [Test]
        public void Should_Parse_HHmm()
        {
            var date = DataType.Parse(new TM(), "0922");
            Assert.AreEqual("0922", date.Value);
            Assert.AreEqual(9, date.Hour);
            Assert.AreEqual(22, date.Minute);
            Assert.IsNull(date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new TM(), "0922-0200");
            Assert.AreEqual("0922-0200", date.Value);
            Assert.AreEqual(9, date.Hour);
            Assert.AreEqual(22, date.Minute);
            Assert.IsNull(date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(2, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_HHmmss()
        {
            var date = DataType.Parse(new TM(), "111102");
            Assert.AreEqual("111102", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(02, date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102-0215");
            Assert.AreEqual("111102-0215", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(02, date.Second);
            Assert.IsNull(date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(2, date.OffsetHours);
            Assert.AreEqual(15, date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_HHmmss_s()
        {
            var date = DataType.Parse(new TM(), "111102.4");
            Assert.AreEqual("111102.4", date.Value);

            date = DataType.Parse(new TM(), "111102.4-0500");
            Assert.AreEqual("111102.4-0500", date.Value);
        }

        [Test]
        public void Should_Parse_HHmmss_ss()
        {
            var date = DataType.Parse(new TM(), "111102.04");
            Assert.AreEqual("111102.04", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(40, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.24");
            Assert.AreEqual("111102.24", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(240, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);


            date = DataType.Parse(new TM(), "111102.04-0500");
            Assert.AreEqual("111102.04-0500", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(40, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.24-0800");
            Assert.AreEqual("111102.24-0800", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(240, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(8, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_HHmmss_sss()
        {
            var date = DataType.Parse(new TM(), "111102.004");
            Assert.AreEqual("111102.004", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(4, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.014");
            Assert.AreEqual("111102.014", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(14, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.104");
            Assert.AreEqual("111102.104", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(104, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.124");
            Assert.AreEqual("111102.124", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(124, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.004-0500");
            Assert.AreEqual("111102.004-0500", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(4, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.014-0500");
            Assert.AreEqual("111102.014-0500", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(14, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.104-0500");
            Assert.AreEqual("111102.104-0500", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(104, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.124-0500");
            Assert.AreEqual("111102.124-0500", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(124, date.Millisecond);
            Assert.IsNull(date.TenThousandths);
            Assert.AreEqual(5, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);
        }

        [Test]
        public void Should_Parse_HHmmss_ssss()
        {
            var date = DataType.Parse(new TM(), "111102.3645");
            Assert.AreEqual("111102.3645", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(364, date.Millisecond);
            Assert.AreEqual(5, date.TenThousandths);
            Assert.IsNull(date.OffsetHours);
            Assert.IsNull(date.OffsetMinutes);

            date = DataType.Parse(new TM(), "111102.3645+0400");
            Assert.AreEqual("111102.3645+0400", date.Value);
            Assert.AreEqual(11, date.Hour);
            Assert.AreEqual(11, date.Minute);
            Assert.AreEqual(2, date.Second);
            Assert.AreEqual(364, date.Millisecond);
            Assert.AreEqual(5, date.TenThousandths);
            Assert.AreEqual(4, date.OffsetHours);
            Assert.AreEqual(0, date.OffsetMinutes);
        }
    }
}
