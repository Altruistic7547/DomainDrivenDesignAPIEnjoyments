using ProjectManagement.Domain.BusinessModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories.Interface
{
    public interface IModel3DRepository
    {
        Task<IEnumerable<Model3D>> GetModel3DsAsync();

        Task<Model3D> GetModel3DAsync(int id);

        Task<Model3D> CreateModel3DAsync(Model3D model3dData);

        Task<Model3D> UpdateModel3DAsync(Model3D model3dData);

        Task<bool> DeleteModel3DAsync(int id);
    }
}
