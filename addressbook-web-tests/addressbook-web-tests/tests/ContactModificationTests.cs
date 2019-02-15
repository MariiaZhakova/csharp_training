using System;
using System.Collections.Generic;
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
            ContactData newContactData = new ContactData("Dmitrii");
            newContactData.Lastname = "Zhakov";
            newContactData.Middlename = "Vladimirovich";

            app.Contacts.CheckIfContactIsPresent();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(newContactData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
