using ProjectManagement.Domain.BusinessModels.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories.Interface
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync();

        Task<Project> GetProjectById(int id);

        Task<Project> CreateProjectAsync(Project projectData);

        Task<bool> UpdateProjectAsync(Project projectData);

        Task<bool> DeleteProjectAsync(int id);
    }
}
