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

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactPage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }
        public ContactHelper Modify(ContactData newData)
        {
            if(GetCountContact() == 0)
            {
                CreateNewTempContact();
            }
            manager.Navigator.GoToContactPage();
            SelectContactForEdit();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();

            return this;
        }
        public ContactHelper Remove()
        {
            if (GetCountContact() == 0)
            {
                CreateNewTempContact();
                manager.Navigator.GoToHomePage();
            }
            SelectContactForEdit();
            SelectContactForDelete();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private void CreateNewTempContact()
        {
            ContactData contact = new ContactData("Mariia");
            contact.Lastname = "Zhakova";
            contact.Notes = "For temp";
            Create(contact);
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }


        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
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
        public ContactHelper SubmitContactRemoval()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        //public int GetNumbersOfContact()
        //{
        //    String value = driver.FindElement(By.Id("search_count")).GetAttribute();
        //    Console.Write(value);
        //    int returnedValue = Int32.Parse(value);
        //    return returnedValue;

        //}

        public int GetCountContact()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

    }
}
