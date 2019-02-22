using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Console.WriteLine("fromForm homePhone = " + fromForm.HomePhone);
            Console.WriteLine("fromForm mobilePhone = " + fromForm.MobilePhone);
            Console.WriteLine("fromForm workPhone = " + fromForm.WorkPhone);
            Console.WriteLine("fromForm Email =" + fromForm.Email);
            Console.WriteLine("fromForm Email2 =" + fromForm.Email2);
            Console.WriteLine("fromForm allPhones =" + fromForm.AllPhones);
            Console.WriteLine("fromForm allEmails =" + fromForm.AllEmails);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            //Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    }
}
