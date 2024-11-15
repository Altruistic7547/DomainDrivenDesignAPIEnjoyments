using ProjectMangement.Application.DataObjects.Model3D;
using ProjectMangement.Application.Model3D.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Services.Interface
{
    public interface IModel3DDataService
    {
        Task<IEnumerable<GetModelsData>> GetModelsDataAsync();

        Task<IEnumerable<GetModelsData>> GetValidatedModelsDataAsync();

        Task<GetModelsData> GetModelsData(int id);

        Task<int> CreateModelAsync(AddModel3DRequest request);

        Task<int> UpdateModelAsync(EditModel3DRequest request);

        Task<bool> RemoveModelAsync(int id);
    }
}
