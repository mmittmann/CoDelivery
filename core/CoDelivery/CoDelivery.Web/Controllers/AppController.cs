using System.Security.Claims;
using System.Web.Mvc;
using CoDelivery.Web.Configs;
using Microsoft.AspNet.Identity;

namespace CoDelivery.Web.Controllers
{
    public abstract class AppController : Controller
    {
        protected AppUser CurrentUser { get { return new AppUser(this.User as ClaimsPrincipal); } }
        protected string UserName { get { return CurrentUser.Identity.GetUserId(); } }
    }
}