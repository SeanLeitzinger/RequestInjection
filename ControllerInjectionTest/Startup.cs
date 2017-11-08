using ControllerInjectionTest.Injectables;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControllerInjectionTest
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IContextExample, ContextExample>();
            services.AddTransient<IExampleRepository, ExampleRepository>();
            services.AddTransient<IServiceExample, ServiceExample>();
            services.AddTransient<IExtraInjectable1, ExtraInjectable1>();
            services.AddTransient<IExtraInjectable2, ExtraInjectable2>();
            services.AddTransient<IExtraInjectable3, ExtraInjectable3>();
            services.AddTransient<IExtraInjectable4, ExtraInjectable4>();

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
