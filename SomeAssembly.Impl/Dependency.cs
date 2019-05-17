using SomeAssembly.Contracts;

namespace SomeAssembly.Impl
{
    public class Dependency : IDependency
    {
        public int Call()
        {
            return 5;
        }
    }
}
