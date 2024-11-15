using Microsoft.AspNetCore.Mvc;
using ProjectMangement.Application.DataObjects.Model3D;
using ProjectMangement.Application.Model3D.Commands;
using ProjectMangement.Application.Model3D.Queries;

namespace PolyForge.AspNetCore.Api.Controllers
{
    [ApiController]
    public class Model3DController : AppBaseController
    {
        /// <summary>
        /// Get all models data.
        /// </summary>
        [HttpGet("Get3DModels")]
        public async Task<IEnumerable<GetModelsData>> GetModels()
        {
            var result = await _mediator.Send(new GetAllModelsRequest());
            return result;
        }

        /// <summary>
        /// Get all validated models data.
        /// </summary>
        [HttpGet("GetValidated3DModels")]
        public async Task<IEnumerable<GetModelsData>> GetValidatedModels()
        {
            var result = await _mediator.Send(new GetAllValidatedModelsRequest());
            return result;
        }

        /// <summary>
        /// Get model data by id.
        /// </summary>
        [HttpGet("Get3DModelById/{id}")]
        public async Task<GetModelsData> GetModel(int id)
        {
            var result = await _mediator.Send(new GetModelRequest { Id = id });
            return result;
        }

        /// <summary>
        /// Create a new 3d model.
        /// </summary>
        [HttpPost("CreateModel3D")]
        public async Task<int> CreateModel(AddModel3DRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        /// <summary>
        /// Update existing 3d model data.
        /// </summary>
        [HttpPut("UpdateModel3D")]
        public async Task<int> UpdateModel(EditModel3DRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        /// <summary>
        /// Remove existing 3d model data.
        /// </summary>
        [HttpDelete("RemoveModel3D/{id}")]
        public async Task<bool> DeleteModel(int id)
        {
            var result = await _mediator.Send(new DeleteModel3DRequest() { Model3DId = id });
            return result;
        }
    }
}
