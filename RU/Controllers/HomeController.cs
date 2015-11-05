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
            var data = from student in db.StudentSet
                group student by student.EnrollmentDate
                into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };
            return View(data);
        }



    }
}
