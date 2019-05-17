using FluentAssertions;
using Solid.Practices.Composition.Container;
using Solid.Practices.Modularity;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XUnitTestProject2
{
    public class UnitTest2
    {
        [Fact]
        public void Test2()
        {
            Assembly assembly = Assembly.LoadFrom("SomeAssembly");

            var typeInfoExtractionService = new TypeInfoExtractionService();
            var moduleType = typeInfoExtractionService.GetTypes(assembly).FirstOrDefault();

            var isType = typeInfoExtractionService.IsCompositionModule(moduleType, typeof(ICompositionModule<IServiceCollection>));
            isType.Should().BeTrue();
        }
    }
}
