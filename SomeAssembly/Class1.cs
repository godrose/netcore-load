using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace SomeAssembly
{
    public class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            throw new System.NotImplementedException();
        }
    }
}
