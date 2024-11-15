using Microsoft.Extensions.DependencyInjection;
using ProjectMangement.Application.Services.Interface;
using ProjectMangement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DependencyInjection
{
    public static class ServicesDependencyInjection
    {
        public static void AddServicesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IProjectDataService, ProjectDataService>();
            services.AddScoped<IModel3DDataService, Model3DDataService>();
        }
    }
}
