using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [HandleError]
        public ActionResult Index()
        {
            throw new Exception("Something happened");
        }

        //
        // GET: /Home/Details/5


        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

     
    }
}
