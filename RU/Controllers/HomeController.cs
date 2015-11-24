using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RU.Models;

namespace RU.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        RUContext db = new RUContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            /*
            var data = from student in db.StudentSet
                group student by student.EnrollmentDate
                into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };
          
             * 
             * 
             * * Use the Database.SqlQuery method for queries that return types that aren't entities. The returned data isn't tracked by the database context, even if you use this method to retrieve entity types.
            */
            var query = "select Enrollmentdate, count(*) as StudentCount from "
                        + "student where enrollmentdate is not null "
                        + "group by EnrollmentDate";
            var data = db.Database.SqlQuery<EnrollmentDateGroup>(query);
            return View(data);
        }



    }
}
