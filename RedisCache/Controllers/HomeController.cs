using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using StackExchange.Redis;

namespace RedisCache.Controllers
{
    public class HomeController : Controller
    {
        private ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("rajredcache.redis.cache.windows.net,password=I98OmZ0xHAme8AQCJYfUs7V9M0rNe9xSPHlhJe3lCYg=");
        private IDatabase cache;

        //
        // GET: /Home/

        public ActionResult Index()
        { cache = conn.GetDatabase();
            cache.StringSet("ola", DateTime.UtcNow.ToString());

            ViewBag.key = cache.StringGet("ola");

            //cache.
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
