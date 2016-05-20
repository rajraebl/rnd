using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RU2.Models;
using RU2.DAL;

namespace RU2.Controllers
{
    public class StudentController : Controller
    {
        private RU2Context db = new RU2Context();

        //
        // GET: /Student/

        public ActionResult Index(string sortOrder,string searchString)
        {
            //var students =from s in db.tblStudent select s;
            var students = db.tblStudent.Select(x => x);
            if (!string.IsNullOrEmpty(searchString))
                students = students.Where(x => //true || 
                    x.LastName.ToUpper().Contains(searchString.ToUpper()) || x.FirstMidName.ToUpper().Contains(searchString.ToUpper()));

            switch (sortOrder)
            {
                case "Name_Desc":
                    students = students.OrderByDescending(x => x.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(x => x.EnrollmentDate);
                    break;
                case "Date_Desc":
                    students = students.OrderByDescending(x => x.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(x => x.LastName);
                    break;
            }

            ViewBag.NameSort = sortOrder == "Name_Desc" ? "Name" : "Name_Desc";
            ViewBag.DateSort = sortOrder == "Date_Desc" ? "Date" : "Date_Desc";
            ViewBag.searchString = searchString;

            return View(students.ToList());
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
        public ActionResult Create([Bind(Include = "FirstName,LastMidName,EnrollmentDate")]Student student)
        {
            try 
            { 
            if (ModelState.IsValid)
            {
                db.tblStudent.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch(Exception)
            {
                //logging
                ModelState.AddModelError("", "Something went wrong");
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

//        The base Controller class already implements the IDisposable interface, so this code simply adds an override to the Dispose(bool) method to explicitly dispose the context instance.
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}