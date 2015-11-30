using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket.Models;

namespace Ticket.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new Company();
            model.Departments = new List<Department>();


            for (int i = 1; i < 3; i++)
            {
                var data = new Department();
                data.DepartmentName = "DepartmentName:" + i;
                data.AdminName = "Admin:" + i;
                model.Departments.Add(data);

            }


            return View(model);
        }

        //public ActionResult showPartialView()
        //{
        //    return View();
        //}
        public PartialViewResult secondPartialView()
        {
            return PartialView("_MySecondPartial");
        }

    }
}
