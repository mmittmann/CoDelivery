using System.Security.Claims;

namespace CoDelivery.Web.Configs
{
    public class AppUser : ClaimsPrincipal
    {
        public AppUser(ClaimsPrincipal principal)
            : base(principal)
        {

        }

        public string Name
        {
            get { return this.FindFirst(ClaimTypes.Name).Value; }
        }

        public string Email
        {
            get { return this.FindFirst(ClaimTypes.Email).Value; }
        }
    }
}