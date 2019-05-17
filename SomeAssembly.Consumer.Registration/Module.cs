using Microsoft.Extensions.DependencyInjection;
using Solid.Practices.Modularity;

namespace SomeAssembly.Consumer.Registration
{
    public class Module : ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<Consumer, Consumer>();
        }
    }
}
