using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    class DeleteContactFromGroup : AuthTestBase
    {
        [Test]

        public void TestDeletingContactFromGroup()
        {
            app.Groups.CheckIfGroupIsPresent();
            app.Contacts.CheckIfContactIsPresent();

            GroupData group = GroupData.GetAllGroups()[0];

            //check that 1 contact is available
            if (group.GetContactsByGroup().Count < 1) 
            {

                if (ContactData.GetAllContacts().Count < 1)
                {
                    app.Contacts.CreateNewTempContact();
                }

                app.Contacts.AddContactToGroup(ContactData.GetAllContacts().First(), group);
            }
            
            List<ContactData> oldList = group.GetContactsByGroup();
            ContactData contact = oldList[0];

            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = GroupData.GetAllGroups()[0].GetContactsByGroup();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
