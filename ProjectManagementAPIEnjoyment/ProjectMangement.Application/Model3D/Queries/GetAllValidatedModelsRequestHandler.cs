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
    public class GetAllValidatedModelsRequestHandler : IRequestHandler<GetAllValidatedModelsRequest, IEnumerable<GetModelsData>>
    {
        private readonly ILogger<GetAllValidatedModelsRequestHandler> _logger;
        private readonly IModel3DDataService _model3DDataService;

        public GetAllValidatedModelsRequestHandler(IModel3DDataService model3DDataService, ILogger<GetAllValidatedModelsRequestHandler> logger)
        {
            _model3DDataService = model3DDataService;
            _logger = logger;

        }

        public Task<IEnumerable<GetModelsData>> Handle(GetAllValidatedModelsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(GetAllValidatedModelsRequestHandler)}");
            return _model3DDataService.GetValidatedModelsDataAsync();

        }
    }
}
