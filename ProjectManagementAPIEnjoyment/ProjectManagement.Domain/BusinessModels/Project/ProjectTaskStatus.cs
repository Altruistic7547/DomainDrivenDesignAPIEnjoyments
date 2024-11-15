
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Domain.BusinessModels.Project
{
    public class ProjectTaskStatus
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
