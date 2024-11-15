using FluentValidation;
using Microsoft.Extensions.Logging;
using ProjectManagement.Domain.BusinessModels.Project;
using ProjectManagement.Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Validators
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        private readonly IProjectStatusRepsitory _projectStatusRepsitory;
        private readonly ILogger<ProjectValidator> _logger;

        public ProjectValidator(IProjectStatusRepsitory projectStatusRepository, ILogger<ProjectValidator> logger)
        {
            _projectStatusRepsitory = projectStatusRepository;
            _logger = logger;

            RuleFor(x => x.StatusId).CustomAsync((property, context, cancelletionToken) => ValidateStatus(property, context));

        }

        private async Task ValidateStatus(int property, ValidationContext<Project> context)
        {
            var projectStatus = (await _projectStatusRepsitory.getProjectStatusesAsync()).FirstOrDefault(x => x.StatusId == property);
            if (projectStatus == null)
            {
                _logger.LogError($"Could not found status with given id : {property}");
                context.AddFailure("Status id is invalid");
            }
        }
    }
}
