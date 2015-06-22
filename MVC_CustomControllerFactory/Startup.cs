using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_CustomControllerFactory.Startup))]
namespace MVC_CustomControllerFactory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
