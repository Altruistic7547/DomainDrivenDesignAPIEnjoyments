using AutoMapper;
using ProjectMangement.Application.ObjectMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DependencyInjection
{
    public static class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<ProjectObjectMaps>();
            configuration.AddProfile<Model3DObjectMaps>();
        }
    }
}
