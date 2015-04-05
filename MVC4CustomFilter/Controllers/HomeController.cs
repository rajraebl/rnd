using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4CustomFilter.Filters;
using MVC4CustomFilter.Models;

namespace MVC4CustomFilter.Controllers
{
    [CustomActionFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message";
            
            return View(db.Emps);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
