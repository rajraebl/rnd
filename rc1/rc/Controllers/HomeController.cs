using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackExchange.Redis;


namespace rc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            IDatabase cache;


            var connectionMultiplexer = ConnectionMultiplexer.Connect("rajredcache.redis.cache.windows.net, password=U6YqstPTkN3+6sHaGvEHasieBfkzAmPG1Yk6+zQRV0M=");
            //var options = new ConfigurationOptions();
            //options.EndPoints.Add("rajredcache.redis.cache.windows.net:6380");
            //options.Ssl = true;
            //options.Password = "I98OmZ0xHAme8AQCJYfUs7V9M0rNe9xSPHlhJe3lCYg=";
            //var connectionMultiplexer = ConnectionMultiplexer.Connect(options);

            cache = connectionMultiplexer.GetDatabase();
            cache.StringSet("ola", DateTime.UtcNow.ToString());

            ViewBag.key = cache.StringGet("ola");

            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
