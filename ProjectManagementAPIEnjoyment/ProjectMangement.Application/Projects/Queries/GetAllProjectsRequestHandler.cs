using MediatR;
using Microsoft.Extensions.Logging;
using ProjectMangement.Application.DataObjects;
using ProjectMangement.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Projects.Queries
{
    public class GetAllProjectsRequestHandler : IRequestHandler<GetAllProjectsRequest, IEnumerable<GetProjectData>>
    {
        private readonly IProjectDataService _dataService;
        private readonly ILogger<GetAllProjectsRequestHandler> _logger;

        public GetAllProjectsRequestHandler(IProjectDataService dataService, ILogger<GetAllProjectsRequestHandler> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public Task<IEnumerable<GetProjectData>> Handle(GetAllProjectsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(GetAllProjectsRequestHandler)}");
            return _dataService.GetAllProjects();
        }
    }
}
