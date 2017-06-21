using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cranberrries.Web.Startup))]
namespace Cranberrries.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
