using Microsoft.Extensions.Logging;
using ProjectManagement.Domain.BusinessModels.Models;
using ProjectManagement.Infrastructure.Context;
using ProjectManagement.Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class Model3dRepository : BaseRepository<Model3D>, IModel3DRepository
    {
        private readonly ILogger<Model3dRepository> _logger;

        public Model3dRepository(ProjectManagementDbContext context, ILogger<Model3dRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Model3D>> GetModel3DsAsync()
        {
            _logger.LogInformation($"Reached At: {nameof(GetModel3DsAsync)}");
            try
            {
                var result = await GetEntitiesAsync();
                _logger.LogInformation($"{nameof(GetModel3DsAsync)} : count : {result.Count}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(GetModel3DsAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not get entities");
            }

        }

        public async Task<Model3D> GetModel3DAsync(int id)
        {
            _logger.LogInformation($"Reached At: {nameof(GetModel3DsAsync)}");
            try
            {
                var result = await GetEntityAsync(id);
                _logger.LogInformation($"{nameof(GetModel3DAsync)} : info : Id : {id}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(GetModel3DAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not get entity");
            }
        }

        public async Task<Model3D> CreateModel3DAsync(Model3D model3dData)
        {
            _logger.LogInformation($"Reached At: {nameof(CreateModel3DAsync)}");
            try
            {
                await AddAsync(model3dData);
                _logger.LogInformation($"{nameof(CreateModel3DAsync)} : info : ");
                return model3dData;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(CreateModel3DAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not create entity");
            }
        }

        public async Task<Model3D> UpdateModel3DAsync(Model3D model3dData)
        {
            _logger.LogInformation($"Reached At: {nameof(UpdateModel3DAsync)}");
            try
            {
                await EditAsync(model3dData);
                _logger.LogInformation($"{nameof(UpdateModel3DAsync)} : info : ");
                return model3dData;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(UpdateModel3DAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not update entity");
            }
        }

        public async Task<bool> DeleteModel3DAsync(int id)
        {
            _logger.LogInformation($"Reached At: {nameof(DeleteModel3DAsync)}");
            try
            {
                await DeleteAsync(id);
                _logger.LogInformation($"{nameof(DeleteModel3DAsync)} : info : ");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(DeleteModel3DAsync)}, Error message : {ex.Message}");
                throw new Exception("Could not delete entity");
            }
        }
    }
}
