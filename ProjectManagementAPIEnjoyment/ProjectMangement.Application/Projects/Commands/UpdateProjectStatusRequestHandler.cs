using MediatR;
using Microsoft.Extensions.Logging;
using ProjectMangement.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Projects.Commands
{
    public class UpdateProjectStatusRequestHandler : IRequestHandler<UpdateProjectStatusRequest, bool>
    {
        private readonly IProjectDataService _dataService;
        private readonly ILogger<UpdateProjectStatusRequestHandler> _logger;

        public UpdateProjectStatusRequestHandler(IProjectDataService dataService, ILogger<UpdateProjectStatusRequestHandler> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public Task<bool> Handle(UpdateProjectStatusRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(AddProjectRequestHandler)}");
            return _dataService.UpdateProjectStatus(request);
        }
    }
}
