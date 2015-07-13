using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace AjaxMVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //TempData["Count"] = TempData["Count"] ?? TempData["Count"] : 0;

            Response.Write(HttpContext.Request.Form["UName"]);

            if (TempData["Count"] == null)
            {
                TempData["Count"] = 1;
                //TempData.Keep("Count");
                return Redirect("/home/index");
            }

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
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

        public ActionResult LoadUser()
        {
            Thread.Sleep(1000);
            IList<User> Users = new List<User>();

            for (int i = 0; i < 5; i++)
            {
                Users.Add(new User() { Id = i, Name = "User :" + i + "" });

            }

            if (Request.IsAjaxRequest())
            {

                return PartialView("_partialView", Users);
            }

            for (int i = 5; i < 10; i++)
            {
                Users.Add(new User() { Id = i, Name = "User :" + i + "" });

            }


            return View(Users);
        }
    }
}
