using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
namespace SimpleHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) .UseUrls("http://localhost:4001","https://localhost:4011")
                .UseStartup<Startup>();
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
			app.Run(context =>
			{
				var data = System.Text.Encoding.UTF8.GetBytes("Hello World from the ASP.Net CORE!");
				context.Response.Body.Write(data, 0, data.Length);
				
				return Task.CompletedTask;
			});
        }
    }
}
