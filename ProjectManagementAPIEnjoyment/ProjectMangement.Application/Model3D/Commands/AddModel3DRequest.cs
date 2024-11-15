using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Model3D.Commands
{
    public class AddModel3DRequest : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int PolygoneCount { get; set; }

        public string FilePath { get; set; }

        public string Model { get; set; }

        public bool IsActive { get; set; }

        public bool IsValidated { get; set; }
    }
}
