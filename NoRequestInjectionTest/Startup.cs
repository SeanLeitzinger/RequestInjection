using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ControllerInjectionTest.Injectables;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace ControllerInjectionTest
{
    public class Startup
    {
        Container container;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            container = new Container();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);

            container.Register<IContextExample, ContextExample>();
            container.Register<IExampleRepository, ExampleRepository>();
            container.Register<IServiceExample, ServiceExample>();
            container.Register<IExtraInjectable1, ExtraInjectable1>();
            container.Register<IExtraInjectable2, ExtraInjectable2>();
            container.Register<IExtraInjectable3, ExtraInjectable3>();
            container.Register<IExtraInjectable4, ExtraInjectable4>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
