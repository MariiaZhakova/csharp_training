using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void MenuProjects()
        {
            OpenManagePage();
            GoToProjectsPage();
        }

        public void OpenManagePage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.20.0/mantisbt-2.20.0/manage_overview_page.php";
        }

        public void GoToProjectsPage()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }
    }
}