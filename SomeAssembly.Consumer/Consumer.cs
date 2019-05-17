using SomeAssembly.Contracts;

namespace SomeAssembly.Consumer
{
    public class Consumer
    {
        private readonly IDependency _dependency;

        public Consumer(IDependency dependency)
        {
            _dependency = dependency;
        }

        public int Do() => _dependency.Call();
    }
}
