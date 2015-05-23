using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsPortal.Web.Startup))]
namespace NewsPortal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
