using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using PagedList;
using System.Web.Mvc;
using RU.Models;

namespace RU.Controllers
{
    public class StudentController : Controller
    {
        private RUContext db = new RUContext();

        //
        // GET: /Student/

        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNo = (page ?? 1);
            if (pageNo < 1)
                pageNo = 1;
            //return View(db.StudentSet.ToList());
            return View(db.StudentSet.OrderBy(x=>x.LastName).ToPagedList(pageNo, pageSize));
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = db.StudentSet.Find(id);
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
        [ValidateAntiForgeryToken] // prevent cross-site request forgery attacks

       // public ActionResult Create([Bind(Exclude = "StudentId")]Student student)
        public ActionResult Create([Bind(Include = "LastName, FirstName, EnrollmentDate")]Student student) //The Bind attribute is added to protect against over-posting.

        {
            try
            {

            
            if (ModelState.IsValid)
            {
                db.StudentSet.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (DataException)
            {

                ModelState.AddModelError("","Unable to save changes. Error.....");
            }
            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = db.StudentSet.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        /*
         Entity States and the Attach and SaveChanges Methods

The database context keeps track of whether entities in memory are in sync with their corresponding rows in the database, and this information determines what happens when you call the SaveChanges method. For example, when you pass a new entity to the Add method, that entity's state is set to Added. Then when you call the SaveChanges method, the database context issues a SQL INSERT command.

An entity may be in one of the following states:

Added. The entity does not yet exist in the database. The SaveChanges method must issue an INSERT statement.
Unchanged. Nothing needs to be done with this entity by the SaveChanges method. When you read an entity from the database, the entity starts out with this status.
Modified. Some or all of the entity's property values have been modified. The SaveChanges method must issue an UPDATE statement.
Deleted. The entity has been marked for deletion. The SaveChanges method must issue a DELETE statement.
Detached. The entity isn't being tracked by the database context.
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified; //the Modified flag causes the Entity Framework to create SQL statements to update the database row. 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = db.StudentSet.Find(id);
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
            Student student = db.StudentSet.Find(id);
            db.StudentSet.Remove(student);
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