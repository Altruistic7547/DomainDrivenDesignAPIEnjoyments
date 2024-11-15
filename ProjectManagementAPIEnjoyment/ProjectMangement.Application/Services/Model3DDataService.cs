using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ProjectManagement.Infrastructure.Repositories.Interface;
using ProjectMangement.Application.DataObjects.Model3D;
using ProjectMangement.Application.Model3D.Commands;
using ProjectMangement.Application.Services.Interface;
using businessModel = ProjectManagement.Domain.BusinessModels.Models;


namespace ProjectMangement.Application.Services
{
    public class Model3DDataService : IModel3DDataService
    {
        private readonly IModel3DRepository _model3dRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<businessModel.Model3D> _model3dValidator;
        private readonly ILogger<Model3DDataService> _logger;


        public Model3DDataService(IModel3DRepository model3DRepository, IMapper mapper,
            IValidator<businessModel.Model3D> model3dValidator, ILogger<Model3DDataService> logger)
        {
            _model3dRepository = model3DRepository;
            _logger = logger;
            _mapper = mapper;
            _model3dValidator = model3dValidator;

        }

        public async Task<IEnumerable<GetModelsData>> GetModelsDataAsync()
        {
            _logger.LogInformation($"Reached At: {nameof(GetModelsDataAsync)}");
            try
            {
                var result = (await _model3dRepository.GetModel3DsAsync()).AsEnumerable();
                return _mapper.Map<IEnumerable<GetModelsData>>(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(GetModelsDataAsync)}, Error message : {ex.Message}");
                throw new Exception("Service could not get entity");
            }
        }

        public async Task<IEnumerable<GetModelsData>> GetValidatedModelsDataAsync()
        {
            _logger.LogInformation($"Reached At: {nameof(GetValidatedModelsDataAsync)}");
            try
            {
                var result = (await _model3dRepository.GetModel3DsAsync()).Where(x => x.IsValidated).AsEnumerable();
                return _mapper.Map<IEnumerable<GetModelsData>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(GetValidatedModelsDataAsync)}, Error message : {ex.Message}");
                throw new Exception("Service could not get entity");
            }
        }

        public async Task<GetModelsData> GetModelsData(int id)
        {
            _logger.LogInformation($"Reached At: {nameof(GetModelsData)}");
            try
            {
                var result = (await _model3dRepository.GetModel3DAsync(id));
                return _mapper.Map<GetModelsData>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(GetValidatedModelsDataAsync)}, Error message : {ex.Message}");
                throw new Exception("Service could not get entity");
            }

        }

        public async Task<int> CreateModelAsync(AddModel3DRequest request)
        {
            _logger.LogInformation($"Reached At: {nameof(CreateModelAsync)}");
            try
            {
                var newModel = _mapper.Map<businessModel.Model3D>(request);

                var validationResult = _model3dValidator.Validate(newModel);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                var result = await _model3dRepository.CreateModel3DAsync(newModel);

                return result.Id;

            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Error occured on validation at {nameof(CreateModelAsync)}, Error message : {ex.Message}");
                throw;
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(CreateModelAsync)}, Error message : {ex.Message}");
                throw new Exception("Service could not create entity");
            }
        }

        public async Task<int> UpdateModelAsync(EditModel3DRequest request)
        {
            _logger.LogInformation($"Reached At: {nameof(UpdateModelAsync)}");
            try
            {
                var model3dRecord = await _model3dRepository.GetModel3DAsync(request.Model3DId);
                if (model3dRecord == null)
                {
                    _logger.LogError($"Could not found model data with given id : {request.Model3DId}");
                    throw new Exception("model3d id is invalid");
                }

                var newModel = _mapper.Map(request, model3dRecord);

                var validationResult = _model3dValidator.Validate(newModel);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                var result = await _model3dRepository.UpdateModel3DAsync(newModel);

                return result.Id;
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Error occured on validation at {nameof(UpdateModelAsync)}, Error message : {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(UpdateModelAsync)}, Error message : {ex.Message}");
                throw new Exception("Service could not update entity");
            }
        }

        public async Task<bool> RemoveModelAsync(int id)
        {
            _logger.LogInformation($"Reached At: {nameof(RemoveModelAsync)}");
            try
            {
                var model3dRecord = await _model3dRepository.GetModel3DAsync(id);
                if (model3dRecord == null)
                {
                    _logger.LogError($"Could not found model data with given id : {id}");
                    throw new Exception("model3d id is invalid");
                }

                return await _model3dRepository.DeleteModel3DAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured on {nameof(RemoveModelAsync)}, Error message : {ex.Message}");
                throw new Exception("Service could not remove entity");
            }
        }
    }

}
