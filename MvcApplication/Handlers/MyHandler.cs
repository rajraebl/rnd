using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Handlers
{
    public class MyHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get {return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("This is from custom handler");
        }
    }
}