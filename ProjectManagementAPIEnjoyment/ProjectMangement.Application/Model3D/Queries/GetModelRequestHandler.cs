using MediatR;
using Microsoft.Extensions.Logging;
using ProjectMangement.Application.DataObjects.Model3D;
using ProjectMangement.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Model3D.Queries
{
    public class GetModelRequestHandler : IRequestHandler<GetModelRequest, GetModelsData>
    {
        private readonly ILogger<GetModelRequestHandler> _logger;
        private readonly IModel3DDataService _model3DDataService;

        public GetModelRequestHandler(IModel3DDataService model3DDataService, ILogger<GetModelRequestHandler> logger)
        {
            _model3DDataService = model3DDataService;
            _logger = logger;
        }

        public Task<GetModelsData> Handle(GetModelRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(GetAllModelsRequestHandler)}");
            return _model3DDataService.GetModelsData(request.Id);

        }
    }
}
