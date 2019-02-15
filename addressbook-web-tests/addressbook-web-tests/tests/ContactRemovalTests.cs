﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            app.Contacts.CheckIfContactIsPresent();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
