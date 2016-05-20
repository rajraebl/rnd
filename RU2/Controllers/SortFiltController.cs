using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RU2.DAL;

namespace RU2.Controllers
{
    public class SortFiltController : Controller
    {
        RU2Context db = new RU2Context();
        //
        // GET: /SortFilt/

        public ActionResult Index()
        {
            var studens = db.tblStudent;
            return View(studens);
        }

        //
        // GET: /SortFilt/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SortFilt/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SortFilt/Create

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
        // GET: /SortFilt/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SortFilt/Edit/5

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
        // GET: /SortFilt/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SortFilt/Delete/5

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
