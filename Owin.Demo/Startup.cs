using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace Owin.Demo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            /* ANOTHER MIDDLEWARE OF OWIN STARTS HERE. THIS SECTION CAN BE COMMENTED*/
            app.Use(async (ctx, next) =>
            {
                Debug.WriteLine("Incoming request:" + ctx.Request.Path);
                await next();
                Debug.WriteLine("Outgoing request:" + ctx.Request.Path);
            });
            /* ANOTHER MIDDLEWARE OF OWIN ENDS HERE. THIS SECTION CAN BE COMMENTED*/
            
            app.Use(async (ctx, next) =>
            {
                //await ctx.Response.WriteAsync("Jai Sri Ram");
                await ctx.Response.WriteAsync("<html><body>Jai Sri Ram</body></html>");
            });
        }
    }
}