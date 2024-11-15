using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Model3D.Commands
{
    public class DeleteModel3DRequest : IRequest<bool>
    {
        public int Model3DId { get; set; }
    }
}
