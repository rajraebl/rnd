using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DateMePlease.Startup))]
namespace DateMePlease
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
