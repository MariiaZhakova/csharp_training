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
            app.Groups.CheckIfGroupIsPresent();
            app.Contacts.CheckIfContactIsPresent();

            GroupData group = GroupData.GetAllGroups()[0]; 
            List<ContactData> oldList = group.GetContactsByGroup();

            int i = ContactData.GetAllContacts().Except(oldList).Count();
            if (i == 0)
            {
                app.Contacts.Create(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }

            ContactData contact = ContactData.GetAllContacts().Except(oldList).First(); 

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContactsByGroup();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}
