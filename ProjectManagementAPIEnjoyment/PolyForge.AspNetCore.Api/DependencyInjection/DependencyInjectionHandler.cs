using ProjectManagement.DependencyInjection;

namespace PolyForge.AspNetCore.Api.DependencyInjection
{
    internal static class DependencyInjectionHandler
    {
        internal static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProjectManagementDependencyInjection(configuration);
        }
    }
}
