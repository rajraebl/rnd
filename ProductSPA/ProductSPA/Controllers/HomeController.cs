using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductSPA.Data;

namespace ProductSPA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TrainingProductVM vm = new TrainingProductVM();
            vm.HandleRequest();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(TrainingProductVM vm)
        {
            vm.HandleRequest();
            ModelState.Clear();


            return View(vm);
        }

    }
}
