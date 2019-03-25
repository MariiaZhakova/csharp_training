using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            OpenMainPage();
            FillLoginForm(account);
            Login();
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.20.0/mantisbt-2.20.0/account_page.php";
        }

        public void FillLoginForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            Login();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
        }

        public void Login()
        {
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}