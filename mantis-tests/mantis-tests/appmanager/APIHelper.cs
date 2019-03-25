using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] mantisList = client.mc_projects_get_user_accessible(account.Name, account.Password);
            int projectCount = mantisList.Length;
            List<ProjectData> projectList = new List<ProjectData>();            
            for (int i = 0; i <= projectCount - 1; i++)
            {
                projectList.Add(new ProjectData() {Name = mantisList[i].name, Description = mantisList[i].description});
            }            
            return projectList;
        }

        public void CreateProjectForRemove(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData addedProject = new Mantis.ProjectData();
            addedProject.name = project.Name;
            addedProject.description = project.Description;
            client.mc_project_add(account.Name, account.Password, addedProject);
        }
    }
}