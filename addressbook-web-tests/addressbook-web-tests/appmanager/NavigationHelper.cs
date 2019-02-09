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
            //driver.FindElement(By.Name("user")).Click();
            //driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                && IsElementPresent(By.Name("new"))) 
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactPage()
        {

            if (driver.Url.Contains("edit.php?id=")
                && IsElementPresent(By.Name("submit")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }


        public void GoToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);

        }
    }
}
