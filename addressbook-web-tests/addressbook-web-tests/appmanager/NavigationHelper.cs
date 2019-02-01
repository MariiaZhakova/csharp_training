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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            :base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();

        }
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }


        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
