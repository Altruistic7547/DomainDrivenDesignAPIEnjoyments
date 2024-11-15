using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Domain.BusinessModels.Project;
using ProjectMangement.Application.Validators;
using businessModel = ProjectManagement.Domain.BusinessModels.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;

namespace ProjectManagement.DependencyInjection
{
    public static class ValidationsDependencyInjection
    {
        public static void AddValidationDependencyInjection(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddTransient<IValidator<Project>, ProjectValidator>();
            services.AddTransient<IValidator<businessModel.Model3D>, Model3DValidator>();
        }
    }
}
