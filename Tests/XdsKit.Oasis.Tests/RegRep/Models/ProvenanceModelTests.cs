﻿using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class ProvenanceModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>("Resources.Models.ProvenanceModel_Test01.xml");

            Assert.AreEqual(1, list.Organizations.Count);

            var org = list.Organizations[0];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7n", org.Id);
            Assert.AreEqual("https://services.xdskit.com/organizations", org.Home);
            Assert.AreEqual(0, org.Slots.Count);
            Assert.NotNull(org.Name);
            Assert.AreEqual("XdsKit, Inc.", org.Name.GetValue("en-US"));
            Assert.AreEqual("XdsKit, Inc.", org.Name.GetValue());
            Assert.NotNull(org.Description);
            Assert.AreEqual("Main XdsKit organization record", org.Description.GetValue("en-US"));
            Assert.AreEqual("Main XdsKit organization record", org.Description.GetValue());
            Assert.IsNull(org.VersionInfo);
            Assert.AreEqual(0, org.Classifications.Count);
            Assert.AreEqual(0, org.ExternalIdentifiers.Count);
            Assert.IsNullOrEmpty(org.LocalId);
            Assert.IsNullOrEmpty(org.ObjectType);
            Assert.IsNullOrEmpty(org.Status);
            Assert.IsNullOrEmpty(org.Parent);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7m", org.PrimaryContact);
            Assert.AreEqual(2, org.Addresses.Count);
            OasisAssert.PostalAddress(org.Addresses[0], "123", "Sesame St", "New York", "NY", "10212", "US");
            OasisAssert.PostalAddress(org.Addresses[1], "400", "Principal Way", "Philadelphia", "PA", "19101", "US");

            Assert.AreEqual(3, org.TelephoneNumbers.Count);
            OasisAssert.Telephone(org.TelephoneNumbers[0], "1", "513", "555-1212", "", "Home");
            OasisAssert.Telephone(org.TelephoneNumbers[1], "44", "212", "555-3000", "2010", "Work");
            OasisAssert.Telephone(org.TelephoneNumbers[2], "2", "212", "555-8080", "30", "Fax");

            Assert.AreEqual(1, org.EmailAddresses.Count);
            OasisAssert.Email(org.EmailAddresses[0], "haboustak@xdskit.com", "Company");

            Assert.AreEqual(1, list.Persons.Count);
            var person = list.Persons[0];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7m", person.Id);
            Assert.AreEqual("https://services.xdskit.com/person", person.Home);
            Assert.AreEqual(0, person.Slots.Count);
            Assert.NotNull(person.Name);
            Assert.AreEqual("Michael Haboustak", person.Name.GetValue("en-AU"));
            Assert.AreEqual(null, person.Name.GetValue());
            Assert.NotNull(person.Description);
            Assert.AreEqual("This object represents an ebRIM person", person.Description.GetValue("en-GB"));
            Assert.AreEqual(null, person.Description.GetValue());
            Assert.IsNull(person.VersionInfo);
            Assert.AreEqual(0, person.Classifications.Count);
            Assert.AreEqual(0, person.ExternalIdentifiers.Count);
            Assert.IsNullOrEmpty(person.LocalId);
            Assert.IsNullOrEmpty(person.ObjectType);
            Assert.IsNullOrEmpty(person.Status);
            Assert.AreEqual("Michael", person.PersonName.FirstName);
            Assert.AreEqual("M", person.PersonName.MiddleName);
            Assert.AreEqual("Haboustak", person.PersonName.LastName);

            Assert.AreEqual(2, person.Addresses.Count);
            OasisAssert.PostalAddress(person.Addresses[0], "123", "Sesame St", "New York", "NY", "10212", "US");
            OasisAssert.PostalAddress(person.Addresses[1], "400", "Principal Way", "Philadelphia", "PA", "19101", "US");

            Assert.AreEqual(3, person.TelephoneNumbers.Count);
            OasisAssert.Telephone(person.TelephoneNumbers[0], "1", "513", "555-1212", "1040", "Home");
            OasisAssert.Telephone(person.TelephoneNumbers[1], "44", "212", "555-3000", "2010", "Work");
            OasisAssert.Telephone(person.TelephoneNumbers[2], "2", "212", "555-8080", "30", "Fax");

            Assert.AreEqual(1, list.Users.Count);

            var user = list.Users[0];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7p", user.Id);
            Assert.AreEqual("https://services.xdskit.com/user", user.Home);
            Assert.AreEqual(0, user.Slots.Count);
            Assert.NotNull(user.Name);
            Assert.AreEqual("Mike Haboustak", user.Name.GetValue("en-US"));
            Assert.AreEqual("Mike Haboustak", user.Name.GetValue());
            Assert.NotNull(user.Description);
            Assert.AreEqual("This object represents an ebRIM user", user.Description.GetValue("en-US"));
            Assert.AreEqual("This object represents an ebRIM user", user.Description.GetValue());
            Assert.IsNull(user.VersionInfo);
            Assert.AreEqual(0, user.Classifications.Count);
            Assert.AreEqual(0, user.ExternalIdentifiers.Count);
            Assert.IsNull(user.LocalId);
            Assert.IsNull(user.ObjectType);
            Assert.IsNull(user.Status);
            Assert.AreEqual("Mike", user.PersonName.FirstName);
            Assert.AreEqual("M", user.PersonName.MiddleName);
            Assert.AreEqual("Haboustak", user.PersonName.LastName);

            Assert.AreEqual(2, user.Addresses.Count);
            OasisAssert.PostalAddress(user.Addresses[0], "123", "Sesame St", "New York", "NY", "10212", "US");
            OasisAssert.PostalAddress(user.Addresses[1], "400", "Principal Way", "Philadelphia", "PA", "19101", "US");

            Assert.AreEqual(3, user.TelephoneNumbers.Count);
            OasisAssert.Telephone(user.TelephoneNumbers[0], "1", "513", "555-1212", "1040", "Home");
            OasisAssert.Telephone(user.TelephoneNumbers[1], "44", "212", "555-3000", "2010", "Work");
            OasisAssert.Telephone(user.TelephoneNumbers[2], "2", "212", "555-8080", "30", "Fax");

            Assert.AreEqual(2, list.Associations.Count);
            OasisAssert.Association(list.Associations[0], "urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                AssociationType.AffiliatedWith, 
                list.Persons[0].Id, list.Organizations[0].Id);
            OasisAssert.Association(list.Associations[1], "urn:xdskit:com:c7ptmx37tfbcwy8ky7q",
                AssociationType.AffiliatedWith, 
                list.Users[0].Id, list.Organizations[0].Id);
        }

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Models.ProvenanceModel_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RegistryObjectList>();
            list.DeepEquals(list2);
        }

        private RegistryObjectList Build_Test01()
        {
            var list = new RegistryObjectList
            {
                Persons = new List<Person>
                {
                    new Person
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        Home = "https://services.xdskit.com/person",
                        Name = XmlUtil.LocalString("Michael Haboustak", "UTF-8", "en-AU"),
                        Description = XmlUtil.LocalString("This object represents an ebRIM person", "UTF-8", "en-GB"),
                        Addresses = new List<PostalAddress>
                        {
                            new PostalAddress
                            {
                                StreetNumber = "123",
                                Street = "Sesame St",
                                PostalCode = "10212",
                                City = "New York",
                                StateOrProvince = "NY",
                                Country = "US"
                            },
                            new PostalAddress
                            {
                                StreetNumber = "400",
                                Street = "Principal Way",
                                PostalCode = "19101",
                                City = "Philadelphia",
                                StateOrProvince = "PA",
                                Country = "US"
                            }
                        },
                        PersonName = new PersonName
                        {
                            MiddleName = "M",
                            LastName = "Haboustak",
                            FirstName = "Michael"
                        },
                        TelephoneNumbers = new List<TelephoneNumber>
                        {
                            new TelephoneNumber
                            {
                                CountryCode = "1",
                                AreaCode = "513",
                                Number = "555-1212",
                                Extension = "1040",
                                PhoneType = "Home"
                            },
                            new TelephoneNumber
                            {
                                CountryCode = "44",
                                AreaCode = "212",
                                Number = "555-3000",
                                Extension = "2010",
                                PhoneType = "Work"
                            },
                            new TelephoneNumber
                            {
                                CountryCode = "2",
                                AreaCode = "212",
                                Number = "555-8080",
                                Extension = "30",
                                PhoneType = "Fax"
                            }
                        },
                        EmailAddresses = new List<EmailAddress>
                        {
                            new EmailAddress
                            {
                                Address = "haboustak@xdskit.com",
                                Type = "Employee"
                            }
                        }
                    }
                },
                Users = new List<User>
                {
                    new User
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7p",
                        Home = "https://services.xdskit.com/user",
                        Name = XmlUtil.LocalString("Mike Haboustak"),
                        Description = XmlUtil.LocalString("This object represents an ebRIM user"),
                        Addresses = new List<PostalAddress>
                        {
                            new PostalAddress
                            {
                                StreetNumber = "123",
                                Street = "Sesame St",
                                PostalCode = "10212",
                                City = "New York",
                                StateOrProvince = "NY",
                                Country = "US"
                            },
                            new PostalAddress
                            {
                                StreetNumber = "400",
                                Street = "Principal Way",
                                PostalCode = "19101",
                                City = "Philadelphia",
                                StateOrProvince = "PA",
                                Country = "US"
                            }
                        },
                        PersonName = new PersonName
                        {
                            MiddleName = "M",
                            LastName = "Haboustak",
                            FirstName = "Mike"
                        },
                        TelephoneNumbers = new List<TelephoneNumber>
                        {
                            new TelephoneNumber
                            {
                                CountryCode = "1",
                                AreaCode = "513",
                                Number = "555-1212",
                                Extension = "1040",
                                PhoneType = "Home"
                            },
                            new TelephoneNumber
                            {
                                CountryCode = "44",
                                AreaCode = "212",
                                Number = "555-3000",
                                Extension = "2010",
                                PhoneType = "Work"
                            },
                            new TelephoneNumber
                            {
                                CountryCode = "2",
                                AreaCode = "212",
                                Number = "555-8080",
                                Extension = "30",
                                PhoneType = "Fax"
                            }
                        },
                        EmailAddresses = new List<EmailAddress>
                        {
                            new EmailAddress
                            {
                                Address = "haboustak@xdskit.com",
                                Type = "Employee"
                            }
                        }
                    }
                },
                Organizations = new List<Organization>
                {
                    new Organization
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7n",
                        Home = "https://services.xdskit.com/organizations",
                        PrimaryContact = "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        Name = XmlUtil.LocalString("XdsKit, Inc."),
                        Description = XmlUtil.LocalString("Main XdsKit organization record"),
                        Addresses = new List<PostalAddress>
                        {
                            new PostalAddress
                            {
                                StreetNumber = "123",
                                Street = "Sesame St",
                                PostalCode = "10212",
                                City = "New York",
                                StateOrProvince = "NY",
                                Country = "US"
                            },
                            new PostalAddress
                            {
                                StreetNumber = "400",
                                Street = "Principal Way",
                                PostalCode = "19101",
                                City = "Philadelphia",
                                StateOrProvince = "PA",
                                Country = "US"
                            }
                        },
                        TelephoneNumbers = new List<TelephoneNumber>
                        {
                            new TelephoneNumber
                            {
                                CountryCode = "1",
                                AreaCode = "513",
                                Number = "555-1212",
                                PhoneType = "Home"
                            },
                            new TelephoneNumber
                            {
                                CountryCode = "44",
                                AreaCode = "212",
                                Number = "555-3000",
                                Extension = "2010",
                                PhoneType = "Work"
                            },
                            new TelephoneNumber
                            {
                                CountryCode = "2",
                                AreaCode = "212",
                                Number = "555-8080",
                                Extension = "30",
                                PhoneType = "Fax"
                            }
                        },
                        EmailAddresses = new List<EmailAddress>
                        {
                            new EmailAddress
                            {
                                Address = "haboustak@xdskit.com",
                                Type = "Company"
                            }
                        }
                    }
                },
                Associations = new List<Association>
                {
                    new Association
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                        AssociationType = AssociationType.AffiliatedWith,
                        Source = "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        Target = "urn:xdskit:com:c7ptmx37tfbcwy8ky7n"
                    },
                    new Association
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7q",
                        AssociationType = AssociationType.AffiliatedWith,
                        Source = "urn:xdskit:com:c7ptmx37tfbcwy8ky7p",
                        Target = "urn:xdskit:com:c7ptmx37tfbcwy8ky7n"
                    }
                }
            };

            return list;
        }
    }
}
