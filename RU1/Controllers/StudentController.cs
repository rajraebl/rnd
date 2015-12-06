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
    public class StudentController : Controller
    {
        IStudentRepository repo;

        public StudentController() : this(new StudentRepository(new RU1Context()))
        {

        }

        public StudentController(IStudentRepository _repo)
        {
            repo = _repo;
        }

       // RU1Context db = new RU1Context();
        //
        // GET: /Student/

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortOrder = (sortOrder=="Name")? "Name_Desc" : "Name";
            ViewBag.DateSortOrder = (sortOrder=="Date")? "Date_Desc":"Date";
            ViewBag.CurrentFilter = searchString;

            //var students = from s in db.tblStudent select s;
            //var students = db.tblStudent.Select(x=>x);
            var students = repo.getStudents();

            if (!(string.IsNullOrEmpty(searchString)))
            {
                students =
                    students.Where(
                        x =>
                            x.LastName.ToUpper().Contains(searchString.ToUpper()) ||
                            x.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            }


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


            return View(students.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = repo.getStudent(id);
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
        public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")] Student student)
        {
            try
            {

            if (ModelState.IsValid)
            {
                repo.addStudent(student);

                repo.save();
                return RedirectToAction("Index");
            }

            }
            catch (Exception)
            {

               ModelState.AddModelError("","Unable to create. Something went wrong");
            }
            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = repo.getStudent(id);
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
                //db.Entry(student).State = EntityState.Modified
                repo.updateStudent(student);
                repo.save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = repo.getStudent (id);
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
            //Student student = db.tblStudent.Find(id);
            //db.tblStudent.Remove(student);
            //db.SaveChanges();
            repo.deleteStudent(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            repo.Dispose();

            base.Dispose(disposing);
        }
    }
}