using System.Security.Claims;
using System.Web.Mvc;
using CoDelivery.Web.Configs;

namespace CoDelivery.Web.Controllers
{
    public abstract class AppController : Controller
    {
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User as ClaimsPrincipal);
            }
        }
    }
}