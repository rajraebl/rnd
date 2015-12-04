using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RU1.Migrations;
using RU1.Models;

namespace RU1.Controllers
{
    public class CourseController : Controller
    {
        private RU1Context db = new RU1Context();

        //
        // GET: /Course/

        public ActionResult Index()
        {
            var tblcourse = db.tblCourse.Include(c => c.Department);
            return View(tblcourse.ToList());
        }

        //
        // GET: /Course/Details/5

        public ActionResult Details(int id = 0)
        {
            Course course = db.tblCourse.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View();
        }


        //
        // POST: /Course/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId, Title, Credits, DepartmentId")]Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tblCourse.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                //log to logger
                ModelState.AddModelError("", "Something went worng!!");
            }
            PopulateDepartmentsDropDownList(course.DepartmentId);
            return View(course);
        }

        private void PopulateDepartmentsDropDownList(int? departmentId=0)
        {
            ViewBag.DepartmentId = new SelectList(db.tblDepartment, "DepartmentId", "Name", departmentId);
        }

        //
        // GET: /Course/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Course course = db.tblCourse.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            PopulateDepartmentsDropDownList(course.DepartmentId);
            return View(course);
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId, Title, Credits, DepartmentId")]Course course)
        {
            try
            {

            
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Somwthing locha..");
            }
            PopulateDepartmentsDropDownList(course.DepartmentId);
            return View(course);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Course course = db.tblCourse.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.tblCourse.Find(id);
            db.tblCourse.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}