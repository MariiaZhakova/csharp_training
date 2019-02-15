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
    public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Dmitrii" + Stopwatch.GetTimestamp());
            newContactData.Lastname = "Zhakov" + Stopwatch.GetTimestamp();
            newContactData.Middlename = "Vladimirovich" + Stopwatch.GetTimestamp();

            app.Contacts.CheckIfContactIsPresent();

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(newContactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetCountContact());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newContactData, contact);
                }
            }
        }

    }
}
