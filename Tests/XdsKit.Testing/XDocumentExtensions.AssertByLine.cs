using System;
using System.Linq;
using System.Xml.Linq;

using NUnit.Framework;

namespace XdsKit
{
    public static partial class XDocumentExtensions
    {
        public static void AssertByLine(this XDocument expected, XDocument actual)
        {
            // MH comparing XML by string sucks... but this is usable for my porpoises
            var str1 = expected.Normalize().ToString();
            var str2 = actual.Normalize().ToString();

            var expectedLines = str1.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            var actualLines = str2.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var smallest = Math.Min(expectedLines.Count(), actualLines.Count());
            for (var i = 0; i < smallest; i++)
                Assert.That(
                    expectedLines[i].Equals(actualLines[i], StringComparison.OrdinalIgnoreCase), 
                    string.Format("Xml differs at line {0}.\r\n{1}\r\n{2}", (i+1), expectedLines[i], actualLines[i]));

            Assert.AreEqual(expectedLines.Count(), actualLines.Count(), "Xml has a different number of lines");
        }

    }
}
