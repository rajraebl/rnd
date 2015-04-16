using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedisCache.Utils;
using StackExchange.Redis;

namespace RedisCache.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            IDatabase cache = CacheUtil.Connection.GetDatabase();
            cache.StringSet("ola", DateTime.UtcNow.ToString());
            ViewBag.key = cache.StringGet("ola");
            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details()
        {
            ServiceProxy proxy = new ServiceProxy();
            var kk = proxy.GetCars();
            return View(kk);
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
