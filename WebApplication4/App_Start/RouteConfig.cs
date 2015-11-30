using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication4
{
    public class RouteConfig
    {
        //http://sampathloku.blogspot.in/2013/11/attribute-routing-with-aspnet-mvc-5.html
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //You can keep the Convention-based Routing also with the same file but routes.MapMvcAttributeRoutes(); Should configure before the Convention-based Routing

            //to enable Attribute Routing of mvc 5
            routes.MapMvcAttributeRoutes();
            //for web api above wud be config.MapHttpAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
