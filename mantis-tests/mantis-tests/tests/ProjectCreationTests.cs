using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Name = "ProjectName",
                Description = "Description"
            };
            app.LogIn.Login(account);
            app.Menu.MenuProjects();

            List<ProjectData> oldProjects = app.API.GetProjects(account);
            app.Project.CreateProject(project);
            List<ProjectData> newProjects = app.API.GetProjects(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}