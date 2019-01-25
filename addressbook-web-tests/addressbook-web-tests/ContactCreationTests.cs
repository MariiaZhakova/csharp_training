using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToContactPage();
            ContactData contact = new ContactData("Mariia");
            contact.Lastname = "Zhakova";
            contact.Notes = "First contact created";
            FillContactForm(contact);
            SubmitContactCreation();
            Logout();
        }

    }
}
