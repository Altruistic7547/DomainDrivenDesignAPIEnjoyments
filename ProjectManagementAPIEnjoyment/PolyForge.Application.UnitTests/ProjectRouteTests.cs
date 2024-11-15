using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectMangement.Application.Projects.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyForge.Application.UnitTests
{
    [TestClass]
    public class ProjectRouteTests : RouteTestBase
    {

        public ProjectRouteTests() : base("/api/project")
        {
        }

        [TestMethod]
        public async Task GetProjectsRouteTest()
        {
            await RouteTestAsync("getprojects", HttpMethod.Get);
        }

        [TestMethod]
        public async Task GetProjectByIdRouteTest()
        {
            await RouteTestAsync("GetProjectById/0", HttpMethod.Get);
        }

        [TestMethod]
        public async Task CreateProjectRouteTest()
        {
            await RouteTestAsync("CreateProject", HttpMethod.Post, new AddProjectRequest { Budget = 200, Name = "ABC", StatusId = 1, Description = "DD" });
        }


        [TestMethod]
        public async Task UpdateProjectStatusRouteTest()
        {
            await RouteTestAsync("Project/2/UpdateProjectStatus/3", HttpMethod.Put);
        }


        [TestMethod]
        public async Task RemoveProjectRouteTest()
        {
            await RouteTestAsync("RemoveProject/11", HttpMethod.Delete);
        }


    }
}
