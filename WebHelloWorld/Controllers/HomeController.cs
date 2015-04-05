using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebHelloWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var kk = CloudConfigurationManager.GetSetting("mySetting");
            var kk = RoleEnvironment.GetConfigurationSettingValue("mySetting");
            ViewBag.ola = kk;
            if (string.IsNullOrEmpty(kk))
                ViewBag.ola = "null value";
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