using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using RU4.ViewModel;
using System.Web.Mvc;
using RU4.Models;
using RU4.DAL;

namespace RU4.Controllers
{
    public class InstructorController : Controller
    {
        private RU4Context db = new RU4Context();

        //
        // GET: /Instructor/

        public ActionResult Index(int? id, int? courseId)
        {
            
            //var tblinstructor = db.tblInstructor.Include(i => i.OfficeAssignment);
            //return View(tblinstructor.ToList());
            var vm = new InstructorIndexData();
            vm.Instructors = db.tblInstructor.Include(c => c.OfficeAssignment);

            if (id != null) {
                ViewBag.selectedrow = id;

                vm.Courses = vm.Instructors.Where(x => x.InstructorID == id).Single().Courses;
            }

            if (courseId != null)
            {
                ViewBag.CourseId = courseId;
                vm.Enrollments = vm.Courses.Where(x => x.CourseId == courseId).Single().Enrollments;
            }

            return View(vm);

        }

        //
        // GET: /Instructor/Details/5

        public ActionResult Details(int id = 0)
        {
            Instructor instructor = db.tblInstructor.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        //
        // GET: /Instructor/Create

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.tblOfficeAssignment, "InstructorID", "Location");
            return View();
        }

        //
        // POST: /Instructor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.tblInstructor.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.tblOfficeAssignment, "InstructorID", "Location", instructor.InstructorID);
            return View(instructor);
        }

        //
        // GET: /Instructor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Instructor instructor = db.tblInstructor.Find(id);
            //if (instructor == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.InstructorID = new SelectList(db.tblOfficeAssignment, "InstructorID", "Location", instructor.InstructorID);
            Instructor instructor = db.tblInstructor.Include(x => x.OfficeAssignment)
                .Where(y => y.InstructorID == id).Single();
            return View(instructor);
        }

        //
        // POST: /Instructor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.tblOfficeAssignment, "InstructorID", "Location", instructor.InstructorID);
            return View(instructor);
        }

        //
        // GET: /Instructor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Instructor instructor = db.tblInstructor.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        //
        // POST: /Instructor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.tblInstructor.Find(id);
            db.tblInstructor.Remove(instructor);
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