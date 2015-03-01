using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoDelivery.Web.Startup))]
namespace CoDelivery.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
