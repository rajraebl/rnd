using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RU4.Models;
using RU4.DAL;

namespace RU4.Controllers
{
    public class StudentController : Controller
    {
        private RU4Context db = new RU4Context();

        //
        // GET: /Student/

        public ActionResult Index(string sortOrder, string searchString)
        {
            var students = db.tblStudent.Select(x=>x);
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(x => x.LastName.ToUpper().Contains(searchString.ToUpper()) || x.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            }

            ViewBag.NameSortOrder =  (sortOrder == "Name") ? "Name_Desc": "Name";
            ViewBag.DateSortOrder = (sortOrder == "Date") ? "Date_Desc" : "Date";
            ViewBag.searchString = searchString;

            switch (sortOrder)
            {
                case "Name_Desc":
                    students = students.OrderByDescending(x=>x.LastName);
                    break;

                case "Date":
                    students = students.OrderBy(x=>x.EnrollmentDate);
                    break;

                case "Date_Desc":
                    students = students.OrderByDescending(x => x.EnrollmentDate);
                    break;

                default:
                    break;
            }

            return View(students);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = db.tblStudent.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.tblStudent.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = db.tblStudent.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = db.tblStudent.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.tblStudent.Find(id);
            db.tblStudent.Remove(student);
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