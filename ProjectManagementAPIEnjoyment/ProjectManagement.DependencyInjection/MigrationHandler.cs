using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DependencyInjection
{
    public static class MigrationHandler
    {
        public static void MigrateDatabase(this IApplicationBuilder application)
        {
            using var scope = application.ApplicationServices.CreateScope();

            using var projectDbContext = scope.ServiceProvider.GetRequiredService<ProjectManagementDbContext>();

            try
            {
                projectDbContext.Database.Migrate();
            }
            catch
            {
                throw new Exception("Unable to migrate");
            }
        }
    }
}
