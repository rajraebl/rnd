using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Handlers;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Response.Write("ola");
            c cc = new c();
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult x()
        {//u can test the seequnce of path to be searched for view
            return View();
        }

        public ActionResult xx()
        {//u can test the seequnce of path to be searched for view
            return View();
        }

        public ActionResult Hi()
        {
            Person p = new Person() {age = 20, name = "ramesh"};
            return ola(p);
        }

        public ActionResult ola(object Data)
        {
            return new CustomActionResult(){data = Data};
        }
        //
        // GET: /Home/Details/5

    }

    public class b
    {
        static b()
        {
            HttpContext.Current.Response.Write("2bs");
        }
        public b()
        {
            HttpContext.Current.Response.Write("3bi");
        }

    }

    public class c:b
    {
        static c()
        {
            HttpContext.Current.Response.Write("1cs");
        }
        public c()
        {
            HttpContext.Current.Response.Write("4ci");
        }

    }

}
