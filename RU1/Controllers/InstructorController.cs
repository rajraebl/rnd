using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RU1.Models;

namespace RU1.Controllers
{
    public class InstructorController : Controller
    {
        private RU1Context db = new RU1Context();

        //
        // GET: /Instructor/

        public ActionResult Index(int? id, int? courseId)
        {
            //var tblinstructor = db.tblInstructor.Include(i => i.OfficeAssignment);
            //return View(tblinstructor.ToList());

            var vm = new InstructorIndexData();
            vm.Instructors = db.tblInstructor.Include(i => i.OfficeAssignment)
                .Include(i => i.Courses.Select(c => c.Department))
                .OrderBy(c => c.LastName);

            if (id != null)
            {
                ViewBag.InstructorID = id.Value;
                //vm.Courses = db.tblInstructor.Where(c => c.InstructorId == id).Single().Courses;
                vm.Courses = vm.Instructors.Where(c => c.InstructorId == id).Single().Courses; //more efficient
            }

            if (courseId != null)
            {
                ViewBag.CourseID = courseId;
                vm.Enrollments = vm.Courses.Single(c => c.CourseId == courseId).Enrollments;
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
            ViewBag.InstructorId = new SelectList(db.tblOfficeAssignment, "InstructorId", "Location");
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

            ViewBag.InstructorId = new SelectList(db.tblOfficeAssignment, "InstructorId", "Location", instructor.InstructorId);
            return View(instructor);
        }

        //
        // GET: /Instructor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Instructor instructor = db.tblInstructor.Find(id);
            var instructor = db.tblInstructor.Include(c => c.OfficeAssignment).Include(k=>k.Courses).Where(i => i.InstructorId == id).Single();
            if (instructor == null)
            {
                return HttpNotFound();
            }
            //ViewBag.InstructorId = new SelectList(db.tblOfficeAssignment, "InstructorId", "Location", instructor.InstructorId);
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allCoursesInDb = db.tblCourse;
            var assignedCourses = new HashSet<int>(instructor.Courses.Select(c => c.CourseId));
            var vm = new List<AssignedCourseData>();
            foreach (var course in allCoursesInDb)
            {
                vm.Add(new AssignedCourseData(){CourseId = course.CourseId, Title = course.Title,Assigned = assignedCourses.Contains(course.CourseId)});
            }
            ViewBag.Courses = vm;
        }

        //
        // POST: /Instructor/Edit/5
        //we are receiving selectedCourses in separate parameter for ease of use. However It will be available in FormCollection also. 
        //You can receive selectedCourses as Request.Form["selectedCourses"].ToString() also
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection formCollection, string[] selectedCourses)
        {
            var instructortoUpdate = db.tblInstructor.Include(c => c.OfficeAssignment)
                .Include(m=>m.Courses)
                .Where(i => i.InstructorId == id).Single();
            //update the row selected from db from the values posted from form
            if (TryUpdateModel(instructortoUpdate, "", new string[] {"LastName", "FirstMidName", "HireDate", "OfficeAssignment"}))
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(instructortoUpdate.OfficeAssignment.Location))
                    {
                        instructortoUpdate.OfficeAssignment = null;
                    }

                    UpdateInstructorCourses(selectedCourses, instructortoUpdate);

                    db.Entry(instructortoUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Something went wrong");
                }
            }
            return View(instructortoUpdate);

            //if (ModelState.IsValid)
            //{
            //    db.Entry(instructor).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.InstructorId = new SelectList(db.tblOfficeAssignment, "InstructorId", "Location", instructor.InstructorId);
            //return View(instructor);
        }

        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate) { 
        //if no course is selected then this string array will be empty
            instructorToUpdate.Courses = new List<Course>();

            if (selectedCourses == null)
            {
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);

            foreach (var course in db.tblCourse)
            {
                if (selectedCoursesHS.Contains(course.CourseId.ToString()))
                {
                    instructorToUpdate.Courses.Add(course);
                }
            }

        
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