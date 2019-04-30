using FluentAssertions;
using McMaster.NETCore.Plugins;
using Solid.Practices.Composition.Container;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            PluginLoader loader = PluginLoader.CreateFromAssemblyFile(Path.Combine(Directory.GetCurrentDirectory(),"SomeAssembly.dll"),
                        sharedTypes: new[] { typeof(ICompositionModule<IDependencyRegistrator>) });
            Assembly assembly = loader.LoadDefaultAssembly();

            var typeInfoExtractionService = new TypeInfoExtractionService();
            var moduleType = typeInfoExtractionService.GetTypes(assembly).FirstOrDefault();

            var isType = typeInfoExtractionService.IsCompositionModule(moduleType, typeof(ICompositionModule<IDependencyRegistrator>));
            isType.Should().BeTrue();
        }
    }
}
