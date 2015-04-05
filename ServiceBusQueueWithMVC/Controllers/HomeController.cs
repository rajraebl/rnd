using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

namespace ServiceBusQueueWithMVC.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
        string qName = "svc-bus-002-rajeshqueue";
        QueueClient Client;
        
        public ActionResult Index()
        {
            Client = QueueClient.CreateFromConnectionString(connectionString, qName);
            var namespaceManager =  NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.QueueExists(qName))
            {
               // namespaceManager.CreateQueue("TestQueue");
            }

            

            for (int i = 0; i < 5; i++)
            {
                // Create message, passing a string message for the body
                BrokeredMessage message = new BrokeredMessage("Test message " + i);

                // Set some addtional custom app-specific properties
                message.Properties["TestProperty"] = "TestValue";
                message.Properties["Message number"] = i;
                message.Properties["timestamp"] = DateTime.Now.ToString();

                // Send message to the queue
                Client.Send(message);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.longmsg = "1234567890";
            ViewBag.shortmsg = "123456";
           

            Client = QueueClient.CreateFromConnectionString(connectionString, qName);
            BrokeredMessage message = Client.Receive();

            while (message != null)
            {
                message = Client.Receive();

                if (message != null)
                {
                    try
                    {
                        ViewBag.str += message.Properties["Message number"] + "@" + "Body: " + message.GetBody<string>() + "MessageID: " + message.MessageId + "Test Property: " + message.Properties["TestProperty"] + "@" + message.Properties["timestamp"] + "<br>";
                        // Remove message from queue
                        message.Complete();
                    }
                    catch (Exception)
                    {
                        // Indicate a problem, unlock message in queue
                        message.Abandon();
                    }
                }
            } 

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
