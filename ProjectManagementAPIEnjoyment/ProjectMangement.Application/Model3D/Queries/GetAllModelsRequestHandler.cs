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
    public class GetAllModelsRequestHandler : IRequestHandler<GetAllModelsRequest, IEnumerable<GetModelsData>>
    {
        private readonly ILogger<GetAllModelsRequestHandler> _logger;
        private readonly IModel3DDataService _model3DDataService;

        public GetAllModelsRequestHandler(IModel3DDataService model3DDataService, ILogger<GetAllModelsRequestHandler> logger)
        {
            _model3DDataService = model3DDataService;
            _logger = logger;
        }

        public Task<IEnumerable<GetModelsData>> Handle(GetAllModelsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(GetAllModelsRequestHandler)}");
            return _model3DDataService.GetModelsDataAsync();
        }
    }
}
