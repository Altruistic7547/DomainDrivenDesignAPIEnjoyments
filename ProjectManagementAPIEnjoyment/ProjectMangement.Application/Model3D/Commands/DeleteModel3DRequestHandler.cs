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
    public class DeleteModel3DRequestHandler : IRequestHandler<DeleteModel3DRequest, bool>
    {
        private readonly IModel3DDataService _dataService;
        private readonly ILogger<DeleteModel3DRequestHandler> _logger;

        public DeleteModel3DRequestHandler(IModel3DDataService dataService, ILogger<DeleteModel3DRequestHandler> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public Task<bool> Handle(DeleteModel3DRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(DeleteModel3DRequestHandler)}");
            return _dataService.RemoveModelAsync(request.Model3DId);

        }
    }
}
