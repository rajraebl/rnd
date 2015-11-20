using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var instructor = db.InstructorSet
                .Include(x => x.OfficeAssignment)
                .Include(x=>x.Corses)
                .Where(x => x.InstructorId == id)
                .Single();

            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allCourses = db.CourseSet;
            var instructorCourses = new HashSet<int>(instructor.Corses.Select(c => c.CourseID));
            var vm = new List<AssignedCourseData>();
            //For each course, the code checks whether the course exists in the instructor's Courses navigation property. 
            foreach (var course in allCourses)
            {
                vm.Add(new AssignedCourseData()
                {
                    CourseId = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }

            ViewBag.Courses = vm;
        }

        //
        // POST: /Instructor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id , FormCollection formCollection, string[] selectedCourses)
        {
            //Gets the current Instructor entity from the database using eager loading for the OfficeAssignment navigation property.
            var instructorToUpdate = db.InstructorSet
                .Include(x => x.OfficeAssignment)
                .Include(x=>x.Corses)
                .Where(x => x.InstructorId == id)
                .Single();

            //TryUpdateModel Updates the specified model instance using values from the controller's current value provider, a prefix, and included properties.
            //TryUpdateModel updates the model property value from the provider(here form collection) only. you need to call db.savechanges explicitly to persist to storage.
            //TryUpdateModel() allows you to bind parameters to your model inside your action. 
            //This is useful if you want to load your model from a database then update it based on user input rather than taking the entire model from user input.
            //attempts to bind a bunch of different input data sources (HTTP POST data coming from a View, QueryString values, Session variables/Cookies, etc.) to the explicit model object you indicate as a parameter. 
            //Essentially, it is only for model binding.
            if (TryUpdateModel(instructorToUpdate, "", new string[] {"LastName", "FirstMidName", "HireDate", "OfficeAssignment"}))
            {
                try
                {
                    if (string.IsNullOrEmpty(instructorToUpdate.OfficeAssignment.Location))
                    {
                        instructorToUpdate.OfficeAssignment = null;
                    }

                    UpdateInstructorCourses(selectedCourses, instructorToUpdate);

                    db.Entry(instructorToUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("","Unable to save try again");
                }

            }
            /*
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorId = new SelectList(db.OfficeAssignmentSet, "InstructorId", "Location", instructor.InstructorId);*/
            return View();
        }

        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate)
        {
            //If no check boxes were selected, the code in UpdateInstructorCourses initializes the Courses navigation property with an empty collection:
            if (selectedCourses == null)
            {
                instructorToUpdate.Corses = new Collection<Course>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>(instructorToUpdate.Corses.Select(c => c.CourseID));

            foreach (var course in db.CourseSet)
            {//If the check box for a course was selected but the course isn't in the Instructor.Courses navigation property, the course is added to the collection in the navigation property.
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.Corses.Add(course);
                    }
                }
                //If the check box for a course wasn't selected, but the course is in the Instructor.Courses navigation property, the course is removed from the navigation property.
                else
                {
                    if (instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.Corses.Remove(course);
                    }
                }
            }

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
            //Instructor instructor = db.InstructorSet.Find(id);
            var instructor = db.InstructorSet.Include(c => c.OfficeAssignment)
                .Single(x => x.InstructorId == id);

            //If you try to delete an instructor who is assigned to a department as administrator, you'll get a referential integrity error.
            instructor.OfficeAssignment = null;

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