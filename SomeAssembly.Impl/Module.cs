using Microsoft.Extensions.DependencyInjection;
using Solid.Practices.Modularity;
using SomeAssembly.Contracts;

namespace SomeAssembly.Impl
{
    public class Module : ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<IDependency, Dependency>();
        }
    }
}
