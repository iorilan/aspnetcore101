using System;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
namespace HttpServer2
{
    ////need to run as admin .
    class Program
    {
        static void Main(string[] args)
        {
            var host = new NancyHost(new Uri("http://localhost:1099"));
            host.Start();

            Console.WriteLine("nancy server started. press enter to exit");
            Console.ReadLine();
        }


    }
    public class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            this.ContractResolver = new CamelCasePropertyNamesContractResolver();
            this.Formatting = Formatting.Indented;
        }
    }

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            Console.WriteLine("boostraper");
            base.ConfigureApplicationContainer(container);

            container.Register(typeof(JsonSerializer), typeof(CustomJsonSerializer));
        }
    }
    public class Module : NancyModule
    {
        public Module()
        {
            Get("/greet/{name}", x => {
                return string.Concat("Hello ", x.name);
            });
            Post("/login", args => this.Login());
        }

         private Response Login()
        {

           var json = "{result:\"ok\"}";
            var jsonBytes = Encoding.UTF8.GetBytes(json);
           Console.Write($" /Login Post {json}");
            return new Response
            {
                ContentType = "application/json",
                Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
            };
        }
    }
}
