using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MVC_CustomControllerFactory.Services;

namespace MVC_CustomControllerFactory.Controllers
{
    public class HomeController : Controller
    {
        private ILoggerService loggerService;


       /* public HomeController()
            : this(new UnityContainer().LoadConfiguration("ola").Resolve<ILoggerService>())
        {
            //var container = new UnityContainer();
            //    container.LoadConfiguration("ola");
            //   new HomeController(container.Resolve<ILoggerService>());
        }
        */
        public HomeController(ILoggerService loggerServicex)
        {
            this.loggerService = loggerServicex;
        }
        public ActionResult Index()
        {
            loggerService.Log("This is Index");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}