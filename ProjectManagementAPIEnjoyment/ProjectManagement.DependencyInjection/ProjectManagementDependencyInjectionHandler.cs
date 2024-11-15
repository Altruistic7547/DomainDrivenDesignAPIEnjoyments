using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Infrastructure.Context;
using ProjectMangement.Application.Projects.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DependencyInjection
{
    public static class ProjectManagementDependencyInjectionHandler
    {
        public static void AddProjectManagementDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectManagementDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddTransient<IProjectManagementDbContext>(provider => (IProjectManagementDbContext)provider.GetService(typeof(ProjectManagementDbContext)));

            services.AddRepositoriesDependencyInjection();
            services.AddServicesDependencyInjection();
            services.AddValidationDependencyInjection();

            services.AddAutoMapper((serviceProvider, configuration) =>
            {
                AutoMapperConfig.Configure(configuration);
            }, AppDomain.CurrentDomain.GetAssemblies());

            services.AddMediatR(typeof(GetAllProjectsRequest));

        }
    }
}
