using MediatR;
using ProjectMangement.Application.DataObjects.Model3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Model3D.Queries
{
    public class GetAllModelsRequest : IRequest<IEnumerable<GetModelsData>>
    {
    }
}
