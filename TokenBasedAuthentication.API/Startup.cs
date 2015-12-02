using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

//notice the “assembly” attribute which states which class to fire on start-up. 
[assembly: OwinStartup(typeof(TokenBasedAuthentication.API.Startup))]
namespace TokenBasedAuthentication.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}