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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
        : base(manager)
        {
            
        }
        public void Login(AccountData account)
        {
            if (IsLogedIn())
            {
                if (IsLogedIn(account))
                {
                    return;
                }
                Logout();
            }

            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            if (IsLogedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
            
        }

        public bool IsLogedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLogedIn(AccountData account)
        {
            return IsLogedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                   == "(" + account.Username + ")";
        }
    }
}
