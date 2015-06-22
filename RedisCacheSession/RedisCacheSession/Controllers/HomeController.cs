using System;
using System.Web.Mvc;
using RedisCacheSession.Models;
using StackExchange.Redis;

namespace RedisCacheSession.Controllers
{
    public class HomeController : Controller
    {
        private Car c = new Car() {Id = 100, Model = "Toyoto"};
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            Session["Hello"] = "Hello World";
            Session["mycar"] = c;
            Response.Write("session Created");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            Response.Write("The value of string in session:");
            Response.Write(Convert.ToString(Session["Hello"]));
            Response.Write("<br>The value of object in session:");

            Car myCar;
            
            if (Session["mycar"] != null)
            {
                myCar = Session["mycar"] as Car;
                Response.Write(Convert.ToString(myCar.Model));

            }

            return View();


        }

        public ActionResult Contact()
        {
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("127.0.0.1,ssl=false");

            IDatabase cache = connection.GetDatabase();

            // Perform cache operations using the cache object...
            // Simple put of integral data types into the cache
            cache.StringSet("key1", "value");
            cache.StringSet("key2", 25);

            // Simple get of data types from the cache
            string key1 = cache.StringGet("key1");
            int key2 = (int)cache.StringGet("key2");

            Session.Abandon();
            ViewBag.Message = "Your contact page.";
            Response.Write("session removed");
            return View();
        }
    }

   
}
