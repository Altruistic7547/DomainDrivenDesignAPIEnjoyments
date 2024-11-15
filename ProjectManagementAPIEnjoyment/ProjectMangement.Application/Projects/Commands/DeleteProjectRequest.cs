using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Projects.Commands
{
    public class DeleteProjectRequest : IRequest<bool>
    {
        public int ProjectId { get; set; }
    }
}
