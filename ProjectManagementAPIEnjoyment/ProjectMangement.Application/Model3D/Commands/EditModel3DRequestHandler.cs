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
    public class EditModel3DRequestHandler : IRequestHandler<EditModel3DRequest, int>
    {
        private readonly ILogger<EditModel3DRequestHandler> _logger;
        private readonly IModel3DDataService _model3DDataService;

        public EditModel3DRequestHandler(IModel3DDataService model3DDataService, ILogger<EditModel3DRequestHandler> logger)
        {
            _model3DDataService = model3DDataService;
            _logger = logger;
        }

        public Task<int> Handle(EditModel3DRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reached at : {nameof(EditModel3DRequestHandler)}");
            return _model3DDataService.UpdateModelAsync(request);
        }
    }
}
