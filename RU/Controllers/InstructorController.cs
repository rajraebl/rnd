using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using RU.Models;

namespace RU.Controllers
{
    public class InstructorController : Controller
    {
        private RUContext db = new RUContext();

        //
        // GET: /Instructor/

        public ActionResult Index(int? id, int? courseId)
        {
            var vm = new InstructorIndexData();
            vm.Instructors = db.InstructorSet
                .Include(i => i.OfficeAssignment)
                .Include((i => i.Corses.Select(c => c.Department)))
                .OrderBy(i => i.LastName);

            //Fill all the instructor but fill(in the InstructorIndexData) only those courses which are tought by selected InstructorID
            if (id != null)
            {
                ViewBag.InstructorId = id.Value;
                //The Where method returns a collection
                //The Single method converts the collection into a single Instructor entity
                //Single().Corses selects all Courses taught by that selected single Instructor
                //we cud have written this like vm.Instructors.Single(i => i.InstructorID == id.Value)
                vm.Courses = vm.Instructors.Where(i => i.InstructorId == id.Value).Single().Corses;
            }

            //fill only those enrollemnts which belong to selected Course
            if (courseId != null)
            {
                ViewBag.CourseId = courseId.Value;
                vm.Enrollments = vm.Courses.Where(x => x.CourseID == courseId).Single().Enrollments;
            }


            //var instructorset = db.InstructorSet.Include(i => i.OfficeAssignment);
            return View(vm);
        }

        //
        // GET: /Instructor/Details/5

        public ActionResult Details(int id = 0)
        {
            Instructor instructor = db.InstructorSet.Find(id);
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
            ViewBag.InstructorId = new SelectList(db.OfficeAssignmentSet, "InstructorId", "Location");
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
                db.InstructorSet.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorId = new SelectList(db.OfficeAssignmentSet, "InstructorId", "Location", instructor.InstructorId);
            return View(instructor);
        }

        //
        // GET: /Instructor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var instructor = db.InstructorSet.Include(x => x.OfficeAssignment)
                .Where(x => x.InstructorId == id)
                .Single();
            return View(instructor);
        }

        //
        // POST: /Instructor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instructor instructor)
        {
            var instructoR = db.InstructorSet.Include(x => x.OfficeAssignment)
                .Where(x => x.InstructorId == instructor.InstructorId)
                .Single();

            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorId = new SelectList(db.OfficeAssignmentSet, "InstructorId", "Location", instructor.InstructorId);
            return View(instructor);
        }

        //
        // GET: /Instructor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Instructor instructor = db.InstructorSet.Find(id);
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
            Instructor instructor = db.InstructorSet.Find(id);
            db.InstructorSet.Remove(instructor);
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