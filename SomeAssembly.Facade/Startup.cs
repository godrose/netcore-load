using System.IO;
using System.Linq;
using LogoFX.Server.Bootstrapping.Mvc;
using McMaster.NETCore.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Solid.Bootstrapping;
using BootstrapperBase = LogoFX.Server.Bootstrapping.BootstrapperBase;

namespace SomeAssembly.Facade
{
    public sealed class Startup
    {               
        public Bootstrapper ConfigureServices(IServiceCollection services)
        {
            Solid.Practices.Composition.AssemblyLoader.LoadAssembliesFromPaths = files =>
                files.Select(r =>
                    PluginLoader.CreateFromAssemblyFile(Path.Combine(Directory.GetCurrentDirectory(), r), config => config.PreferSharedTypes = true)
                        .LoadDefaultAssembly());

            var bootstrapper = new Bootstrapper(services)
                .Use(new RegisterCustomCompositionModulesMiddleware<BootstrapperBase, IServiceCollection>())
                .Use(new RegisterCoreMiddleware<BootstrapperBase>())
                .Use(new RegisterControllersMiddleware<BootstrapperBase>());
            bootstrapper.Initialize();
            return bootstrapper as Bootstrapper;
        }                
    }
}
