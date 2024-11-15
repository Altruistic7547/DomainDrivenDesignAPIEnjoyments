using ProjectManagement.Common.CommonDTO;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Domain.BusinessModels.Models
{
    public class Model3DTag : AddEditAuditData
    {
        [Key]
        public int Id { get; set; }

        public string TagName { get; set; }

        public ICollection<Model3D> Model3Ds { get; set; } = new List<Model3D>();
    }

}
