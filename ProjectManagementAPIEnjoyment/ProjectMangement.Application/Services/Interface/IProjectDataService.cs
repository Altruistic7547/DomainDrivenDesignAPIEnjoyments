using ProjectMangement.Application.DataObjects;
using ProjectMangement.Application.Projects.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Services.Interface
{
    public interface IProjectDataService
    {
        Task<IEnumerable<GetProjectData>> GetAllProjects();

        Task<GetProjectData> GetProjectById(int id);

        Task<int> CreateProject(AddProjectRequest request);

        Task<bool> UpdateProjectStatus(UpdateProjectStatusRequest request);

        Task<bool> RemoveProject(int id);
    }
}
