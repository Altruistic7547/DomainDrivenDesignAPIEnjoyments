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
    public class AddProjectRequestHandler : IRequestHandler<AddProjectRequest, int>
    {
        private readonly IProjectDataService _dataService;
        private readonly ILogger<AddProjectRequestHandler> _logger;
        public AddProjectRequestHandler(IProjectDataService dataService, ILogger<AddProjectRequestHandler> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public Task<int> Handle(AddProjectRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(AddProjectRequestHandler)}");
            return _dataService.CreateProject(request);

        }
    }
}
