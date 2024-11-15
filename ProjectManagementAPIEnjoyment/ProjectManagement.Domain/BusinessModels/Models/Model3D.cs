using ProjectManagement.Common.CommonDTO;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Domain.BusinessModels.Models
{
    public class Model3D : AddEditAuditData
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PolygoneCount { get; set; }

        public string FilePath { get; set; }

        public string Model { get; set; }

        public bool IsActive { get; set; }

        public bool IsValidated { get; set; }

        public ICollection<Model3DTag> Tags { get; set; } = new List<Model3DTag>();
    }
}
