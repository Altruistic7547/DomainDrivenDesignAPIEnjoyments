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
    public class GetProjectByIdRequestHandler : IRequestHandler<GetProjectByIdRequest, GetProjectData>
    {
        private readonly IProjectDataService _dataService;
        private readonly ILogger<GetAllProjectsRequestHandler> _logger;

        public GetProjectByIdRequestHandler(IProjectDataService dataService, ILogger<GetAllProjectsRequestHandler> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }


        public Task<GetProjectData> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(GetAllProjectsRequestHandler)}");
            return _dataService.GetProjectById(request.Id);

        }
    }
}
