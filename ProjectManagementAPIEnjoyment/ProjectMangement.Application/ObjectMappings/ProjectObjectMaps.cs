using AutoMapper;
using ProjectManagement.Domain.BusinessModels.Project;
using ProjectMangement.Application.DataObjects;
using ProjectMangement.Application.Projects.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.ObjectMappings
{
    public class ProjectObjectMaps : Profile
    {
        public ProjectObjectMaps()
        {
            CreateMap<Project, GetProjectData>();

            CreateMap<AddProjectRequest, Project>()
                .ForMember(x => x.ProjectId, y => y.Ignore());
        }
    }
}
