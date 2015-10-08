using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMP.Models;

namespace DMP.Controllers
{
    public class HomeController : Controller
    {
        DMPRepository _repository = new DMPRepository();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var randomProfiles = _repository.GetRandomProfiles(6);

            return View(randomProfiles);
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
