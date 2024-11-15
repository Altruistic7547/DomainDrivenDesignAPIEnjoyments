using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ProjectManagement.Domain.BusinessModels.Project;
using ProjectManagement.Infrastructure.Repositories.Interface;
using ProjectMangement.Application.DataObjects;
using ProjectMangement.Application.Projects.Commands;
using ProjectMangement.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Services
{
    public class ProjectDataService : IProjectDataService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectStatusRepsitory _projectStatusRepsitory;
        private readonly IMapper _mapper;
        private readonly IValidator<Project> _projectValidator;
        private readonly ILogger<ProjectDataService> _logger;

        public ProjectDataService(IProjectRepository projectRepository, IMapper mapper, IProjectStatusRepsitory projectStatusRepsitory,
            IValidator<Project> projectValidator, ILogger<ProjectDataService> logger)
        {
            _projectRepository = projectRepository;
            _projectStatusRepsitory = projectStatusRepsitory;
            _mapper = mapper;
            _projectValidator = projectValidator;
            _logger = logger;
        }

        public async Task<IEnumerable<GetProjectData>> GetAllProjects()
        {
            _logger.LogInformation($"Reached At: {nameof(GetAllProjects)}");
            try
            {
                var result = (await _projectRepository.GetProjectsAsync()).AsEnumerable();
                return _mapper.Map<IEnumerable<GetProjectData>>(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(GetAllProjects)}, Error message : {ex.Message}");
                throw new Exception("Service could not get entity");
            }
        }

        public async Task<GetProjectData> GetProjectById(int id)
        {
            _logger.LogInformation($"Reached At: {nameof(GetProjectById)}");
            try
            {
                var result = (await _projectRepository.GetProjectById(id));
                return _mapper.Map<GetProjectData>(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(GetProjectById)}, Error message : {ex.Message}");
                throw new Exception("Service could not get entity");
            }
        }

        public async Task<int> CreateProject(AddProjectRequest request)
        {
            _logger.LogInformation($"Reached At: {nameof(CreateProject)}");
            try
            {
                var newProject = _mapper.Map<Project>(request);

                var validationResult = await _projectValidator.ValidateAsync(newProject);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                var result = await _projectRepository.CreateProjectAsync(newProject);

                return result.ProjectId;

            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Error occured on validation at {nameof(CreateProject)}, Error message : {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(CreateProject)}, Error message : {ex.Message}");
                throw new Exception("Service could not create entity");
            }

        }

        public async Task<bool> UpdateProjectStatus(UpdateProjectStatusRequest request)
        {
            _logger.LogInformation($"Reached At: {nameof(UpdateProjectStatus)}");
            try
            {
                var projectRecord = await _projectRepository.GetProjectById(request.ProjectId);
                if (projectRecord == null)
                {
                    _logger.LogError($"Could not found project data with given id : {request.ProjectId}");
                    throw new Exception("Project id is invalid");
                }

                projectRecord.StatusId = request.NewStatusId;

                var validationResult = await _projectValidator.ValidateAsync(projectRecord);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                var result = await _projectRepository.UpdateProjectAsync(projectRecord);

                return result;

            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Error occured on validation at {nameof(CreateProject)}, Error message : {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(UpdateProjectStatus)}, Error message : {ex.Message}");
                throw new Exception("Service could not update entity");
            }
        }

        public async Task<bool> RemoveProject(int id)
        {
            _logger.LogInformation($"Reached At: {nameof(RemoveProject)}");
            try
            {
                var projectRecord = await _projectRepository.GetProjectById(id);
                if (projectRecord == null)
                {
                    _logger.LogError($"Could not found project data with given id : {id}");
                    throw new Exception("Project id is invalid");
                }

                var result = await _projectRepository.DeleteProjectAsync(id);

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(RemoveProject)}, Error message : {ex.Message}");
                throw new Exception("Service could not delete entity");
            }

        }
    }
}
