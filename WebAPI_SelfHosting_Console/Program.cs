
using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebAPI_SelfHosting_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8090");
            config.Routes.MapHttpRoute(
                name: "API",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
 
            //Next, we create an instance of the HttpSelfHostServer class and assign to it the configuration, defined above and start the server to listen to a HTTP request.
            using (var httpserver = new HttpSelfHostServer(config))
            {
                httpserver.OpenAsync().Wait();
                Console.Write("HttpSelfHostServer Started and Listening to Requests");
                Console.ReadLine();
            }
        }
    }

}
