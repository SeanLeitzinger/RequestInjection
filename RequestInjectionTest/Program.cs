using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RequestInjectionTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //   .MinimumLevel.Debug()
            //   .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //   .Enrich.FromLogContext()
            //    .WriteTo.Seq("http://localhost:5341")
            //   .CreateLogger();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseSerilog()
                .Build();
    }
}
