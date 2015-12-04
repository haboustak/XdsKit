using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;
using XdsKit.Xdsb.Models;

namespace XdsKit.Tests.Xdsb.Models
{
    [TestFixture]
    public class AuthorTests
    {
        [Test]
        public void Should_Build_Correct_Institution()
        {
            var author = new Author
            {
                Institution = new List<XdsOrganization>
                {
                    new XdsOrganization
                    {
                        Name = "XdsKit.com",
                        OrganizationId = "7764",
                        UniversalId = "1.2.3.4.5"
                    }   
                }
            };
            var institution = author.Institution.First();
            Assert.AreEqual("XdsKit.com", institution.Hl7Organization.OrganizationName.Value);
            Assert.AreEqual("7764", institution.Hl7Organization.OrganizationIdentifier.Value);
            Assert.AreEqual("1.2.3.4.5", institution.Hl7Organization.AssigningAuthority.UniversalId.Value);
            Assert.AreEqual("ISO", institution.Hl7Organization.AssigningAuthority.UniversalIdType.Value);

            Assert.AreEqual(institution.Name, institution.Hl7Organization.OrganizationName.Value);
            Assert.AreEqual(institution.OrganizationId, institution.Hl7Organization.OrganizationIdentifier.Value);
            Assert.AreEqual(institution.UniversalId, institution.Hl7Organization.AssigningAuthority.UniversalId.Value);

            Assert.AreEqual("XdsKit.com^^^^^&1.2.3.4.5&ISO^^^^7764", institution.Hl7Organization.Encode());
        }

        [Test]
        public void Should_Build_Correct_Person()
        {
            var author = new Author
            {
                Person = new XdsPerson
                {
                    IdNumber = "xds01",
                    GivenName = "Mike",
                    SecondandFurtherGivenNames = "M",
                    Surname = "Haboustak",
                    OwnSurname = "oustak",
                    OwnSurnamePrefix = "Hab",
                    Suffix = "Jr.",
                    Prefix = "Mr.",
                    Degree = "MD",
                    ProfessionalSuffix = "JD",
                    UniversalId = "1.2.3.4.5"
                }
            };
            Assert.AreEqual("xds01", author.Person.Hl7Person.IdNumber.Value);
            Assert.AreEqual("Mike", author.Person.Hl7Person.GivenName.Value);
            Assert.AreEqual("M", author.Person.Hl7Person.SecondandFurtherGivenNames.Value);
            Assert.AreEqual("Haboustak", author.Person.Hl7Person.FamilyName.Surname.Value);
            Assert.AreEqual("oustak", author.Person.Hl7Person.FamilyName.OwnSurname.Value);
            Assert.AreEqual("Hab", author.Person.Hl7Person.FamilyName.OwnSurnamePrefix.Value);
            Assert.AreEqual("Jr.", author.Person.Hl7Person.Suffix.Value);
            Assert.AreEqual("Mr.", author.Person.Hl7Person.Prefix.Value);
            Assert.AreEqual("MD", author.Person.Hl7Person.Degree.Value);
            Assert.AreEqual("JD", author.Person.Hl7Person.ProfessionalSuffix.Value);
            Assert.AreEqual("1.2.3.4.5", author.Person.Hl7Person.AssigningAuthority.UniversalId.Value);
            Assert.AreEqual("ISO", author.Person.Hl7Person.AssigningAuthority.UniversalIdType.Value);

            Assert.AreEqual(author.Person.IdNumber, author.Person.Hl7Person.IdNumber.Value);
            Assert.AreEqual(author.Person.GivenName, author.Person.Hl7Person.GivenName.Value);
            Assert.AreEqual(author.Person.SecondandFurtherGivenNames, author.Person.Hl7Person.SecondandFurtherGivenNames.Value);

            Assert.AreEqual("xds01^Haboustak&Hab&oustak^Mike^M^Jr.^Mr.^MD^^&1.2.3.4.5&ISO^^^^^^^^^^^^JD", author.Person.Hl7Person.Encode());
        }


        [Test]
        public void Should_Accept_HL7Person()
        {
            var xcn = DataType.Parse(new XCN(),"xds01^Haboustak&Hab&oustak^Mike^M^Jr.^Mr.^MD^^&1.2.3.4.5&ISO^^^^^^^^^^^^JD");

            var author = new Author
            {
                Person = new XdsPerson(xcn)
            };

            Assert.AreEqual("xds01", author.Person.IdNumber);
            Assert.AreEqual("Mike", author.Person.GivenName);
            Assert.AreEqual("M", author.Person.SecondandFurtherGivenNames);
            Assert.AreEqual("Haboustak", author.Person.Surname);
            Assert.AreEqual("oustak", author.Person.OwnSurname);
            Assert.AreEqual("Hab", author.Person.OwnSurnamePrefix);
            Assert.AreEqual("Jr.", author.Person.Suffix);
            Assert.AreEqual("Mr.", author.Person.Prefix);
            Assert.AreEqual("MD", author.Person.Degree);
            Assert.AreEqual("JD", author.Person.ProfessionalSuffix);
            Assert.AreEqual("1.2.3.4.5", author.Person.UniversalId);

            Assert.AreEqual("xds01^Haboustak&Hab&oustak^Mike^M^Jr.^Mr.^MD^^&1.2.3.4.5&ISO^^^^^^^^^^^^JD", author.Person.Hl7Person.Encode());
        }

        [Test]
        public void Should_Accept_HL7Org()
        {
            var xon = DataType.Parse(new XON(), "XdsKit.com^^^^^&1.2.3.4.5&ISO^^^^7764");

            var author = new Author
            {
                Institution = new List<XdsOrganization>
                {
                    new XdsOrganization(xon)
                }
            };

            Assert.AreEqual("XdsKit.com", author.Institution[0].Name);
            Assert.AreEqual("7764", author.Institution[0].OrganizationId);
            Assert.AreEqual("1.2.3.4.5", author.Institution[0].UniversalId);

            Assert.AreEqual("XdsKit.com^^^^^&1.2.3.4.5&ISO^^^^7764", author.Institution[0].Hl7Organization.Encode());
        }
    }
}
