using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) 
            :base(manager)
        {
        }
      

        public ContactHelper SubmitContactRemoval()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Contacts.Create(contact);
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            return this;
        }


        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
            SelectContactForEdit();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper Remove()
        {
            SelectContactForEdit();
            SelectContactForDelete();
            manager.Navigator.GoToHomePage();
            return this;
        }


        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

 

        public ContactHelper SelectContactForEdit()
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])")).Click();
            return this;
        }
        public ContactHelper SelectContactForDelete()
        {
            driver.FindElement(By.XPath("(//div[@id='content']/form[2]/input[2])")).Click();

            return this;
        }
    }
}
