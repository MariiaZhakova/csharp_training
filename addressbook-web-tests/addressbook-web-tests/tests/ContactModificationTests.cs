using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Dmitrii" + Stopwatch.GetTimestamp());
            newContactData.Lastname = "Zhakov" + Stopwatch.GetTimestamp();
            newContactData.Middlename = "Vladimirovich" + Stopwatch.GetTimestamp();

            app.Contacts.CheckIfContactIsPresent();

            List<ContactData> oldContacts = ContactData.GetAllContacts();
            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(newContactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetCountContact());

            List<ContactData> newContacts = ContactData.GetAllContacts();
            toBeModified.Firstname = newContactData.Firstname;
            toBeModified.Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                {
                    Assert.IsTrue((contact.Firstname == newContactData.Firstname)&&(contact.Lastname == newContactData.Lastname));
                }
            }
        }

    }
}
