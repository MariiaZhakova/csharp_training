using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAllGroups()[0]; 
            List<ContactData> oldList = group.GetContactsByGroup(); 
            ContactData contact = ContactData.GetAllContacts().Except(group.GetContactsByGroup()).First(); 

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContactsByGroup();

            oldList.Add(contact);

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
