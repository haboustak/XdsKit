using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class DTTests
    {
        [Test]
        public void Should_Serialize_yyyy()
        {
            var date = new DT(2015);
            Assert.AreEqual("2015", date.Value);
        }

        [Test]
        public void Should_Serialize_yyyyMM()
        {
            var date = new DT(2015, 4);
            Assert.AreEqual("201504", date.Value);
        }

        [Test]
        public void Should_Serialize_yyyyMMdd()
        {
            var date = new DT(2015, 12, 31);
            Assert.AreEqual("20151231", date.Value);
        }

        [Test]
        public void Should_Serialize_leap_year()
        {
            var date = new DT(2012, 2, 29);
            Assert.AreEqual("20120229", date.Value);
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
        public void Should_Parse_leap_year()
        {
            var date = new DT(2012, 2, 29);
            Assert.AreEqual("20120229", date.Value);
            Assert.AreEqual(2012, date.Year);
            Assert.AreEqual(2, date.Month);
            Assert.AreEqual(29, date.Day);
        }
    }
}
