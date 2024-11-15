using AutoMapper;
using ProjectMangement.Application.DataObjects.Model3D;
using ProjectMangement.Application.Model3D.Commands;
using businessModel = ProjectManagement.Domain.BusinessModels.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangement.Application.ObjectMappings
{
    public class Model3DObjectMaps : Profile
    {
        public Model3DObjectMaps()
        {
            CreateMap<businessModel.Model3D, GetModelsData>();

            CreateMap<AddModel3DRequest, businessModel.Model3D>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Tags, y => y.Ignore());

            CreateMap<EditModel3DRequest, businessModel.Model3D>()
                .ForMember(x => x.Id, y => y.MapFrom(q => q.Model3DId))
                .ForMember(x => x.Tags, y => y.Ignore());
        }
    }
}
