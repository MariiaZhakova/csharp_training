using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
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
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetCountContact());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            foreach (ContactData oldContact in oldContacts)
            {
                Assert.AreNotEqual(oldContact.Id, contact.Id);
            }

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        }

    }
}
