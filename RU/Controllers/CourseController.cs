using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RU.DAL;
using RU.Models;

namespace RU.Controllers
{
    public class CourseController : Controller
    {
        //private RUContext db = new RUContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Course/

        public ActionResult Index()
        {
            //var courseset = db.CourseSet.Include(c => c.Department);
            //return View(courseset.ToList());

            var courses = unitOfWork.CourseRepository.Get(includeProperties: "Department");
            return View(courses);
        }

        //
        // GET: /Course/Details/5

        public ActionResult Details(int id = 0)
        {
            //Course course = db.CourseSet.Find(id);
            //Course course = unitOfWork.CourseRepository.GetById(id);
            var query = "select * from Course where CourseId=@p0";
            Course course = unitOfWork.CourseRepository.GetWithRawSql(query, id).Single();

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
            //ViewBag.DepartmentId = new SelectList(db.DepartmentSet, "DepartmentId", "Name");
            ViewBag.DepartmentId = new SelectList(unitOfWork.DepartmentRepository.Get(orderBy: q=>q.OrderBy(d=>d.Name)), "DepartmentId", "Name");
            return View();
        }

        //
        // POST: /Course/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                //db.CourseSet.Add(course);
                //db.SaveChanges();
                unitOfWork.CourseRepository.Add(course);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(unitOfWork.DepartmentRepository.Get(orderBy:q=>q.OrderBy(x=>x.Name)), "DepartmentId", "Name", course.DepartmentId);
            return View(course);
        }

        //
        // GET: /Course/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Course course = db.CourseSet.Find(id);
            Course course = unitOfWork.CourseRepository.GetById(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(unitOfWork.DepartmentRepository.Get(orderBy:x=>x.OrderBy(q=>q.Name)), "DepartmentId", "Name", course.DepartmentId);
            return View(course);
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(course).State = EntityState.Modified;
                //db.SaveChanges();

                unitOfWork.CourseRepository.Update(course);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(unitOfWork.DepartmentRepository.Get(orderBy:x=>x.OrderBy(n=>n.Name)), "DepartmentId", "Name", course.DepartmentId);
            return View(course);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Course course = db.CourseSet.Find(id);
            Course course = unitOfWork.CourseRepository.GetById(id);
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
            //Course course = db.CourseSet.Find(id);
            //db.CourseSet.Remove(course);
            //db.SaveChanges();

            unitOfWork.CourseRepository.Delete(id);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateCourseCredits(byte? multiplier)
        {
            if (multiplier != null)
            {
                ViewBag.RowsAffected = unitOfWork.CourseRepository.UpdateCourseCredits(multiplier);
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}