using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.Projects.Commands
{
    public class AddProjectRequest : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Budget { get; set; }

        public int StatusId { get; set; }
    }
}
