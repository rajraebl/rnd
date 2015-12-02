using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RU1.Models;

namespace RU1.Controllers
{
    public class HomeController : Controller
    {
        private RU1Context db = new RU1Context();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Statistics()
        {

            var model = from student in db.tblStudent
                group student by student.EnrollmentDate
                into dateGroup
                select new Statistics()
                {
                    EnrollmentDate = dateGroup.Key,
                    Count = dateGroup.Count()
                };

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
