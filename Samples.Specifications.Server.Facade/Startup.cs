using System.IO;
using System.Linq;
using JetBrains.Annotations;
using LogoFX.Server.Bootstrapping.Mvc;
using McMaster.NETCore.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solid.Bootstrapping;
using BootstrapperBase = LogoFX.Server.Bootstrapping.BootstrapperBase;

namespace Samples.Specifications.Server.Facade
{
    internal sealed class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        [UsedImplicitly]
        public IConfiguration Configuration { get; }

        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            //Comment out this statement and add explicit reference to the Server.Api and Storage.MongoDb to see controllers working
            Solid.Practices.Composition.AssemblyLoader.LoadAssembliesFromPaths = files =>
                files.Select(r =>
                    PluginLoader.CreateFromAssemblyFile(Path.Combine(Directory.GetCurrentDirectory(), r), config => config.PreferSharedTypes = true)
                        .LoadDefaultAssembly());
            var bootstrapper = new Bootstrapper(services)
                .Use(new RegisterCustomCompositionModulesMiddleware<BootstrapperBase, IServiceCollection>())
                .Use(new RegisterCoreMiddleware<BootstrapperBase>())
                .Use(new RegisterControllersMiddleware<BootstrapperBase>());            
            bootstrapper.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAny")
                .UseHsts()
                .UseAuthentication()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                }).UseMvc();
        }
    }
}
