using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 10; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(35))
                {
                    Firstname = GenerateRandomString(10),
                    Lastname = GenerateRandomString(10),
                });
            }

            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = ContactData.GetAllContacts();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetCountContact());

            List<ContactData> newContacts = ContactData.GetAllContacts();

            foreach (ContactData oldContact in oldContacts)
            {
                Assert.AreNotEqual(oldContact.Id, contact.Id);
            }

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        }

        //[Test]
        //public void TestDBConnectivityContacts()
        //{
        //    DateTime start = DateTime.Now;
        //    List<ContactData> fromUi = app.Contacts.GetContactsList();
        //    DateTime end = DateTime.Now;
        //    Console.WriteLine("Ui: " + end.Subtract(start));

        //    start = DateTime.Now;
        //    List<ContactData> fromDb = ContactData.GetAllContacts();
        //    end = DateTime.Now;
        //    Console.WriteLine("DB: " + end.Subtract(start));

        //}

    }
}
