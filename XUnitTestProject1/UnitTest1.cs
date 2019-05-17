using FluentAssertions;
using McMaster.NETCore.Plugins;
using Solid.Practices.Composition.Container;
using Solid.Practices.Modularity;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            PluginLoader loader = PluginLoader.CreateFromAssemblyFile(
                Path.Combine(Directory.GetCurrentDirectory(), "SomeAssembly.Impl.dll"),
                r => r.PreferSharedTypes = true);
            
            Assembly assembly = loader.LoadDefaultAssembly();

            var typeInfoExtractionService = new TypeInfoExtractionService();
            var moduleType = typeInfoExtractionService.GetTypes(assembly).FirstOrDefault(t => t.Name == "Module");

            var isType =
                typeInfoExtractionService.IsCompositionModule(moduleType,
                    typeof(ICompositionModule<IServiceCollection>));
            isType.Should().BeTrue();
        }       
    }
}
