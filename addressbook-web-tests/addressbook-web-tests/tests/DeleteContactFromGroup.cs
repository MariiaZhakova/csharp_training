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
            GroupData group = GroupData.GetAllGroups()[0];
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
