using System.ServiceModel;
using System.Threading;
using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ServiceBus.Messaging;

namespace PubApp.Controllers
{
    public class HomeController : Controller
    {
        private string connStr = "Endpoint=sb://rajsbnmsp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8q/vO/Hsj2yVCDCTifq5VjOa/keujf29QEnyAzuHkqY=";
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            
            var tc = TopicClient.CreateFromConnectionString(connStr, "Topic1");
            var bm = new BrokeredMessage("ola");
            bm.Properties["insId"] = "bajajAllianz";
            bm.Properties["insType"] = Request["Message"];
            tc.Send(bm);
            
            return View();
        }

        public ActionResult About()
        {
            //GetValueOld();
            GetValueNew();

            ViewBag.Message = "Your app description page.";

            return View();
        }

        private void GetValueNew()
        {
            var cf = new ChannelFactory<WcfService2.IService1>("endpoint1");
            //cf.Endpoint.Address = new EndpointAddress("http://localhost:29002/Service1.svc");

            var sProxy = cf.CreateChannel();
            Console.WriteLine("calling the service: {0}", "sProxy.GetData(500)");
            var k = "1 2 3 1 2 3 1 2 3 1 2 3 1 2 3 1 2 3".Split();
            foreach (var s in k)
            {
                Thread.Sleep(500);
                Console.WriteLine("calling the method getdata: {0}", s);
                sProxy.GetData(Convert.ToInt32(s));
            }
            Console.WriteLine("calling Done !!!");
        }

        private static void GetValueOld()
        {
            
            var cf = new ChannelFactory<WcfService2.IService1>("endpoint1");
            //cf.Endpoint.Address = new EndpointAddress("http://localhost:29002/Service1.svc");

            var sProxy = cf.CreateChannel();
            Console.WriteLine("calling the service: {0}", "sProxy.GetData(500)");
            var k = "1 2 3 1 2 3 1 2 3 1 2 3 1 2 3 1 2 3".Split();
            foreach (var s in k)
            {
                Thread.Sleep(500);
                Console.WriteLine("calling the method getdata: {0}", s);
                sProxy.GetData(Convert.ToInt32(s));
            }
            Console.WriteLine("calling Done !!!");
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
