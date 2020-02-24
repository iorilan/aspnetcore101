using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BooksODataService
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
}
