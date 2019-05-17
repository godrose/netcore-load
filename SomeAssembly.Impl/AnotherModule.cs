using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace SomeAssembly.Impl
{
    class AnotherModule : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            throw new System.NotImplementedException();
        }
    }
}
