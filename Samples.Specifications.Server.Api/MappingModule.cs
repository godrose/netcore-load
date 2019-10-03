using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Samples.Specifications.Server.Api.Mappers;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Server.Api
{    
    internal sealed class MappingModule : ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            dependencyRegistrator.AddSingleton(mapper);
            dependencyRegistrator.AddSingleton<UserMapper>();
            dependencyRegistrator.AddSingleton<WarehouseMapper>();
        }
    }
}
