using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace PubApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            initPubSub();
        }

        private void initPubSub()
        {
            string connStr = "Endpoint=sb://rajsbnmsp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8q/vO/Hsj2yVCDCTifq5VjOa/keujf29QEnyAzuHkqY=";
            var NamespaceManage = NamespaceManager.CreateFromConnectionString(connStr);
            if(!NamespaceManage.TopicExists("Topic1"))
                NamespaceManage.CreateTopic("Topic1");
            if (!NamespaceManage.SubscriptionExists("Topic1", "Sub1"))
                NamespaceManage.CreateSubscription("Topic1", "Sub1");
            
            clearSubscription();

            SqlFilter sf2Filter = new SqlFilter("insType = 'f2'");
            if (!NamespaceManage.SubscriptionExists("Topic1", "Sub2"))
                NamespaceManage.CreateSubscription("Topic1", "Sub2", sf2Filter);

            SqlFilter sf3Filter = new SqlFilter("insType = 'f3'");
            if (!NamespaceManage.SubscriptionExists("Topic1", "Sub3"))
                NamespaceManage.CreateSubscription("Topic1", "Sub3", sf3Filter);

            if (!NamespaceManage.TopicExists("Topic2"))
                NamespaceManage.CreateTopic("Topic2");

            if (!NamespaceManage.SubscriptionExists("Topic2", "Sub1"))
                NamespaceManage.CreateSubscription("Topic2", "Sub1");
            
            if (!NamespaceManage.SubscriptionExists("Topic2", "Sub2"))
                NamespaceManage.CreateSubscription("Topic2", "Sub2");

        }

        private void clearSubscription()
        {
            string connStr = "Endpoint=sb://rajsbnmsp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8q/vO/Hsj2yVCDCTifq5VjOa/keujf29QEnyAzuHkqY=";
            var NamespaceManage = NamespaceManager.CreateFromConnectionString(connStr);
            if(NamespaceManage.SubscriptionExists("Topic1","Sub2"))
                NamespaceManage.DeleteSubscription("Topic1", "Sub2");

            if (NamespaceManage.SubscriptionExists("Topic1", "Sub3"))
                NamespaceManage.DeleteSubscription("Topic1", "Sub3");

        }



















                public void Application_Error(object s, EventArgs ev)
        {
            Exception ex;
            for (ex = Server.GetLastError(); ex != null; ex = ex.InnerException)
            {
                LogException(ex);
            }
            Server.ClearError();

        }

                private void LogException(Exception ex)
        {
            var message = new StringBuilder();
            
            message.AppendLine(!string.IsNullOrEmpty(Request.UserAgent)
                                   ? string.Format("Unhandled exception, UserAgent is {0}", Request.UserAgent)
                                   : "Unhandled exception, UserAgent is not available");

            message.AppendLine(!string.IsNullOrEmpty(Request.RawUrl)
                                   ? string.Format("Raw URL is {0}", Request.RawUrl)
                                   : "Raw URL is not available");

            message.AppendLine(Request.UrlReferrer != null
                                   ? string.Format("Referer is {0}", Request.UrlReferrer)
                                   : "Referrer is not available");
            message.AppendLine(!string.IsNullOrEmpty(Request.UserHostAddress)
                                   ? string.Format("UserHostAddress is {0}", Request.UserHostAddress)
                                                                      : "UserHostAddress is not available");

            //Logger.Log(ex, message.Append("SessionId is not available").ToString());
            //PerformanceMonitor.Increment(PerformanceCounterNames.UnhandledErrorsPerSecond);
        }

                protected void Application_PreSendRequestHeaders()
                {
                    Response.Headers.Remove("Server");
                }


    }
}