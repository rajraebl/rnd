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

            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem(){Text = "1", Value = "1"});
            lst.Add(new SelectListItem(){Text = "2", Value = "2"});
            lst.Add(new SelectListItem() { Text = "3", Value = "3" });
            lst.Add(new SelectListItem() { Selected = true, Text = "33", Value = "33" });
            lst.Add(new SelectListItem() { Text = "4", Value = "4" });

            //SelectList sl = new SelectList( new {new SelectListItem ()}, "","")};
            ViewBag.ola = lst;

            //----------------------------------------------------
            Emp emp = new Emp() {Id = 4, Name = "Bootstrap"};

            IList<Emp> Emps = new List<Emp>();

            for (int i = 0; i < 9; i++)
            {
                Emps.Add(new Emp(){Id = i, Name = "css:" + i});
            }


            ViewBag.Emps = new SelectList(Emps, "Id", "Name", emp.Id);
            //-------------------------------------------------------

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

    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
