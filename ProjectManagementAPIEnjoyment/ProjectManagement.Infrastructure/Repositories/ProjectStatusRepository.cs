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
    public class ProjectStatusRepository : BaseRepository<ProjectStatus>, IProjectStatusRepsitory
    {
        private ILogger<ProjectStatusRepository> _logger;

        public ProjectStatusRepository(ProjectManagementDbContext context, ILogger<ProjectStatusRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<ProjectStatus>> getProjectStatusesAsync()
        {
            _logger.LogInformation($"Reached At: {nameof(getProjectStatusesAsync)}");
            try
            {
                var result = await GetEntitiesAsync();
                _logger.LogInformation($"{nameof(getProjectStatusesAsync)} : count : {result.Count}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(getProjectStatusesAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not get entities");
            }

        }
    }
}
