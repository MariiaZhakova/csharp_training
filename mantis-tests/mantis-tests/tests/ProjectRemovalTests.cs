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
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            app.LogIn.Login(account);
            app.Menu.MenuProjects();
            app.Project.ProjectExistanceCheck(account);
            List<ProjectData> oldProjects = app.API.GetProjects(account);
            app.Project.DeleteProject(account, 0);
            List<ProjectData> newProjects = app.API.GetProjects(account);
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}