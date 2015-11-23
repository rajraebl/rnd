using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using RU.DAL;
using RU.Models;

namespace RU.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository studentRepository;

        public StudentController()
        {
            this.studentRepository = new StudentRepository(new RUContext());
        }

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        //private RUContext db = new RUContext();

        //
        // GET: /Student/

        public ActionResult Index(string sortOrder, string SearchString)
        {
            ViewBag.SearchString = SearchString;
            //If sord order is name then we will reverse(name_desc) in viewBag and it will go to view to create apposite link
            ViewBag.NameSortParm = (sortOrder == "Name") ? "Name_Desc" : "Name";
            ViewBag.DateSortOrder = (sortOrder == "Date") ? "Date_Desc" : "Date";

            var students = from s in studentRepository.GetStudents() select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                students = students.Where(x => x.FirstName.Contains(SearchString) || x.LastName.Contains(SearchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    students = students.OrderBy(x => x.LastName);
                    break;
                case "Name_Desc":
                    students = students.OrderByDescending(x => x.LastName);
                    break;
                case "Date_Desc":
                    students = students.OrderByDescending(x => x.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(x => x.EnrollmentDate);
                    break;
            }
            return View(students);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = studentRepository.GetStudentById(id);
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
                studentRepository.AddStudent(student);
                studentRepository.Save();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = studentRepository.GetStudentById(id);
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
                //db.Entry(student).State = EntityState.Modified;
                //db.SaveChanges();

                studentRepository.UpdateStudent(student);
                studentRepository.Save();

                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = studentRepository.GetStudentById(id);
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
            //Student student = db.StudentSet.Find(id);
            //db.StudentSet.Remove(student);
            //db.SaveChanges();

            studentRepository.DeleteStudent(id);
            studentRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            studentRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}