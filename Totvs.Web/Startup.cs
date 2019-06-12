using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Totvs.Web.Startup))]
namespace Totvs.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
