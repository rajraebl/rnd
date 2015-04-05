using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInDiffDomain.Controllers
{
    public class MyController : Controller
    {
        //
        // GET: /My/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /My/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /My/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /My/Create

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
        // GET: /My/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /My/Edit/5

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
        // GET: /My/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /My/Delete/5

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
