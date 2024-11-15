using Microsoft.Extensions.Logging;
using ProjectManagement.Domain.BusinessModels.Project;
using ProjectManagement.Infrastructure.Context;
using ProjectManagement.Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly ILogger<ProjectRepository> _logger;
        public ProjectRepository(ProjectManagementDbContext context, ILogger<ProjectRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            _logger.LogInformation($"Reached At: {nameof(GetProjectsAsync)}");
            try
            {
                var result = await GetEntitiesAsync();
                _logger.LogInformation($"{nameof(GetProjectsAsync)} : count : {result.Count}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(GetProjectsAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not get entities");
            }
        }

        public async Task<Project> GetProjectById(int id)
        {
            _logger.LogInformation($"Reached At: {nameof(GetProjectById)}");
            try
            {
                var result = await GetEntityAsync(id);
                _logger.LogInformation($"{nameof(GetProjectById)} : info : Id : {id}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(GetProjectById)}, Error message : {ex.Message}");
                throw new Exception("Could not get entity");
            }
        }

        public async Task<Project> CreateProjectAsync(Project projectData)
        {
            _logger.LogInformation($"Reached At: {nameof(CreateProjectAsync)}");
            try
            {
                await AddAsync(projectData);
                _logger.LogInformation($"{nameof(CreateProjectAsync)} : info : ");
                return projectData;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(CreateProjectAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not create entity");
            }
        }

        public async Task<bool> UpdateProjectAsync(Project projectData)
        {
            _logger.LogInformation($"Reached At: {nameof(UpdateProjectAsync)}");
            try
            {
                var result = await EditAsync(projectData);
                _logger.LogInformation($"{nameof(UpdateProjectAsync)} : info : ");
                return result != null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(UpdateProjectAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not update entity");
            }
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            _logger.LogInformation($"Reached At: {nameof(DeleteProjectAsync)}");
            try
            {
                await DeleteAsync(id);
                _logger.LogInformation($"{nameof(DeleteProjectAsync)} : info : ");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(DeleteProjectAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not delete entity");
            }

        }
    }
}
