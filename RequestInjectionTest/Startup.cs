using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RequestInjectionTest.Data;
using RequestInjectionTest.Data.Injectables;
using RequestInjectionTest.Requests;
using RequestInjector.NetCore;
using System.Linq;
using System.Reflection;

namespace RequestInjectionTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var requestAssembly = typeof(IRequest).GetTypeInfo().Assembly;
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IContextExample, ContextExample>();
            services.AddScoped<IExampleRepository, ExampleRepository>();
            services.AddScoped<IServiceExample, ServiceExample>();
            services.AddScoped<IExtraInjectable1, ExtraInjectable1>();
            services.AddScoped<IExtraInjectable2, ExtraInjectable2>();
            services.AddScoped<IExtraInjectable3, ExtraInjectable3>();
            services.AddScoped<IExtraInjectable4, ExtraInjectable4>();
            services.AddDbContext<RequestInjectionTestDbContext>();

            services.Scan(scan => scan
                            .FromAssembliesOf(typeof(IRequest), typeof(GetTestRequest))
                            .AddClasses()
                            .AsSelf()
                            .WithScopedLifetime());

            var provider = services.BuildServiceProvider();

            services.AddMvc(config =>
            {
                config.ModelMetadataDetailsProviders.Add(new RequestInjectorMetadataProvider());
                config.ModelBinderProviders.Insert(0, new RequestInjectorModelBinderProvider());
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new RequestInjectorHandler<IRequest>(provider));
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
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
