using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerInDiffDomain.Controllers
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    public class MotorController : Controller
    {
        //
        // GET: /Motor/

        public static List<Emp> Emps = new List<Emp>(); 

        public ActionResult Index()
        {
            var bainding = new BasicHttpBinding();
            BindingElementCollection bc = bainding.CreateBindingElements();

            return View();
        }

        //
        // GET: /Motor/Details/5

        public JsonResult Details(int id)
        {
            return Json(Emps,JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Motor/Create

        [HttpPost]
        public JsonResult Create(Emp emp)
        {
            Emp objEmp = new Emp
            {
                Name = emp.Name,
                Id = Emps.Count,
                CDate = DateTime.Now
            };

            Emps.Add(objEmp);
            return Json(objEmp,JsonRequestBehavior.AllowGet);
        }

 
    }
}
