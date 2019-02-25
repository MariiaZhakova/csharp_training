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

        //compare information from table with from edit form
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            
            //Console.WriteLine("fromForm allPhones =" + fromForm.AllPhones);
            //Console.WriteLine("fromForm allEmails =" + fromForm.AllEmails);
            //Console.WriteLine("fromTable allPhones =" + fromTable.AllPhones);
            //Console.WriteLine("fromTable allEmails =" + fromTable.AllEmails);


            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]

        //compare information from edit form with details form
        public void TestContactInformation2()
        {
            string fromDetailsForm = app.Contacts.GetContactInformationFromDetailsForm(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Console.WriteLine("String: " + fromDetailsForm);
            Console.WriteLine("String2: " + fromForm.EditFormInToString);

            //verification
            Assert.AreEqual(fromDetailsForm, fromForm.EditFormInToString);
        }
    }
}
