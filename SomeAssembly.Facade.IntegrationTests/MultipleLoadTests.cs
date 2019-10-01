using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SomeAssembly.Contracts;
using Xunit;

namespace SomeAssembly.Facade.IntegrationTests
{
    public class MultipleLoadTests
    {
        [Fact]
        public void ResolveDependencyTwice_AssembliesAreLoadedTwice_DependenciesAreTheSame()
        {
            var startup = new Startup();
            var serviceCollection = new ServiceCollection();
            startup.ConfigureServices(serviceCollection);

            var dependency1 = serviceCollection.BuildServiceProvider().GetService(typeof(IDependency));            

            startup = new Startup();
            serviceCollection = new ServiceCollection();
            startup.ConfigureServices(serviceCollection);
            var dependency2 = serviceCollection.BuildServiceProvider().GetService(typeof(IDependency));

            dependency1.GetHashCode().Should().Be(dependency2.GetHashCode());
        }
    }
}