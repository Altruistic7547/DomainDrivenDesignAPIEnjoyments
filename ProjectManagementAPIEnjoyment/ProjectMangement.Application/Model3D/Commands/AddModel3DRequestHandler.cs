using MediatR;
using Microsoft.Extensions.Logging;
using ProjectMangement.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Model3D.Commands
{
    public class AddModel3DRequestHandler : IRequestHandler<AddModel3DRequest, int>
    {
        private readonly ILogger<AddModel3DRequestHandler> _logger;
        private readonly IModel3DDataService _model3DDataService;

        public AddModel3DRequestHandler(IModel3DDataService model3DDataService, ILogger<AddModel3DRequestHandler> logger)
        {
            _model3DDataService = model3DDataService;
            _logger = logger;
        }
        public Task<int> Handle(AddModel3DRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(AddModel3DRequestHandler)}");
            return _model3DDataService.CreateModelAsync(request);
        }
    }
}
