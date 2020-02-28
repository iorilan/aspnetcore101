using Microsoft.Extensions.DependencyInjection;
using System;

namespace WithDIContainer
{
    class Program
    {
        static void Main()
        {
            using (ServiceProvider container = RegisterServices())
            {
                var controller = container.GetRequiredService<HomeController>();
                string result = controller.Hello("Katharina");
                Console.WriteLine(result);

                var greet = container.GetRequiredService<IGreetingService>();
                var result2 = greet.Greet("Guest");
                Console.Write(result2);
            }
        }

        static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddTransient<HomeController>();
            return services.BuildServiceProvider();
        }
    }
}
