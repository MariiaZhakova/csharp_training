using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void CreateProject(ProjectData project)
        {
            InitCteateProject();
            FillProjectForm(project);
            SubmitCreation();
        }

        public void DeleteProject(AccountData account, int id)
        {
            OpenProject(id);
            InitDeleteProject();
            SubmitRemoval();
        }

        public void InitCteateProject()
        {
            driver.FindElement(By.XPath("//input[@value='Create New Project']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }

        public void SubmitCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
        }

        public void ProjectExistanceCheck(AccountData account)
        {
            if (manager.API.GetProjects(account).Count() == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "AutoProjectName",
                    Description = "AutoDescription"
                };
                manager.API.CreateProjectForRemove(account, project);
                manager.Driver.Url = "http://localhost/mantisbt-2.20.0/mantisbt-2.20.0/manage_proj_page.php";
            };
        }

        public void OpenProject(int id)
        {
            driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("a"))[id].Click();
        }

        public void InitDeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

        public void SubmitRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }
    }
}