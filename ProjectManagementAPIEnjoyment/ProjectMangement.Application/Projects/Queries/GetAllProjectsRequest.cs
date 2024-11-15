using MediatR;
using ProjectMangement.Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Projects.Queries
{
    public class GetAllProjectsRequest : IRequest<IEnumerable<GetProjectData>>
    {
    }
}
