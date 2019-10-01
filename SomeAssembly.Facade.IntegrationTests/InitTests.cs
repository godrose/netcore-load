using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace SomeAssembly.Facade.IntegrationTests
{
    public class InitTests
    {
        [Fact]
        public void ResolveDependency_AfterInitializeIsDone_DoesntThrowException()
        {
            var startup = new Startup();
            var serviceCollection = new ServiceCollection();
            startup.ConfigureServices(serviceCollection);
            
            var consumer = serviceCollection.BuildServiceProvider().GetService(typeof(Consumer.Consumer));
            consumer.Should().NotBeNull();
        }
    }
}
