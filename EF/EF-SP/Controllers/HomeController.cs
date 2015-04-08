
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using StackExchange.Redis;
using EF_SP.Models;

namespace EF_SP.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //var connectionMultiplexer = ConnectionMultiplexer.Connect("rajredcache.redis.cache.windows.net, password=U6YqstPTkN3+6sHaGvEHasieBfkzAmPG1Yk6+zQRV0M=");
            return View();
        }

        //
        // GET: /Home/Details/5
        [HttpPost]
        public ActionResult Submit(string email)
        {
            using ( var db = new AdContext())
            {
            db.SoftDeleteUserAccountWithDBContextExtensionMethod(email);

            //db.SoftDeleteUserAccountWithObjectContext(email);
            }
            return View("Index");
        }


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
