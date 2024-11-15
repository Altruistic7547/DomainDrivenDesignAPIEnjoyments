using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Infrastructure.Repositories.Interface;
using ProjectManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DependencyInjection
{
    public static class RepositoriesDependancyInjection
    {
        public static void AddRepositoriesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectStatusRepsitory, ProjectStatusRepository>();
            services.AddScoped<IModel3DRepository, Model3dRepository>();
        }
    }
}
