using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.BusinessModels.Models;
using ProjectManagement.Domain.BusinessModels.Project;

namespace ProjectManagement.Infrastructure.Context
{
    public class ProjectManagementDbContext : DbContext, IProjectManagementDbContext
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options) : base(options)
        { }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public DbSet<ProjectStatus> ProjectStatuses { get; set; }

        public DbSet<ProjectTaskStatus> ProjectTaskStatuses { get; set; }

        public DbSet<Model3D> Model3Ds { get; set; }

        public DbSet<Model3DTag> model3DTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectManagementDbContext).Assembly);
        }
    }
}
