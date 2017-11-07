using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequestInjectionTest.Injectables;
using RequestInjectionTest.Requests;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Reflection;

namespace RequestInjectionTest
{
    public class Startup
    {
        Container container;

        public Startup(IConfiguration configuration)
        {
            container = new Container();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var requestAssembly = typeof(IRequest).GetTypeInfo().Assembly;
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);

            container.Register<IContextExample, ContextExample>();
            container.Register<IExampleRepository, ExampleRepository>();
            container.Register<IServiceExample, ServiceExample>();
            container.Register<IExtraInjectable1, ExtraInjectable1>();
            container.Register<IExtraInjectable2, ExtraInjectable2>();
            container.Register<IExtraInjectable3, ExtraInjectable3>();
            container.Register<IExtraInjectable4, ExtraInjectable4>();
            container.RegisterCollection(typeof(IRequest), new[] { requestAssembly });

            services.AddMvc(config =>
            {
                config.ModelMetadataDetailsProviders.Add(new CustomMetadataProvider());
                config.ModelBinderProviders.Insert(0, new QueryModelBinderProvider(container));
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new RequestHandlerConverter<IRequest>(container));
            });
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
