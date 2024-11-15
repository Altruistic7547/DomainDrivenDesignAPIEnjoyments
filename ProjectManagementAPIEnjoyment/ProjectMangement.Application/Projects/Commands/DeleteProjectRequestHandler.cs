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
    public class DeleteProjectRequestHandler : IRequestHandler<DeleteProjectRequest, bool>
    {
        private readonly IProjectDataService _dataService;
        private readonly ILogger<DeleteProjectRequestHandler> _logger;

        public DeleteProjectRequestHandler(IProjectDataService dataService, ILogger<DeleteProjectRequestHandler> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public Task<bool> Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(AddProjectRequestHandler)}");
            return _dataService.RemoveProject(request.ProjectId);
        }
    }
}
