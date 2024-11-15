using Microsoft.AspNetCore.Mvc;
using ProjectMangement.Application.DataObjects;
using ProjectMangement.Application.Projects.Commands;
using ProjectMangement.Application.Projects.Queries;

namespace PolyForge.AspNetCore.Api.Controllers
{
    [ApiController]
    public class ProjectController : AppBaseController
    {
        /// <summary>
        /// Get all project data.
        /// </summary>
        [HttpGet("GetProjects")]
        public async Task<IEnumerable<GetProjectData>> GetProjects()
        {
            var result = await _mediator.Send(new GetAllProjectsRequest());
            return result;
        }

        /// <summary>
        /// Get project data based on project id.
        /// </summary>
        [HttpGet("GetProjectById/{projectId}")]
        public async Task<GetProjectData> GetProjectById(int projectId)
        {
            var result = await _mediator.Send(new GetProjectByIdRequest() { Id = projectId });
            return result;
        }

        /// <summary>
        /// Create a new project data record.
        /// </summary>
        [HttpPost("CreateProject")]
        public async Task<int> CreateProject([FromBody] AddProjectRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        /// <summary>
        /// Update the existing project status.
        /// </summary>
        [HttpPut("Project/{projectId}/UpdateProjectStatus/{newProjectStatusId}")]
        public async Task<bool> UpdateProjectStatus(int projectId, int newProjectStatusId)
        {
            var result = await _mediator.Send(new UpdateProjectStatusRequest() { ProjectId = projectId, NewStatusId = newProjectStatusId });
            return result;
        }

        /// <summary>
        /// Delete the existing project record.
        /// </summary>
        [HttpDelete("RemoveProject/{projectId}")]
        public async Task<bool> DeleteProjectStatus(int projectId)
        {
            var result = await _mediator.Send(new DeleteProjectRequest() { ProjectId = projectId });
            return result;
        }
    }
}
