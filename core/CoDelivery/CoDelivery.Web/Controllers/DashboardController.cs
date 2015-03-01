using System.Web.Mvc;

namespace CoDelivery.Web.Controllers
{
    public class DashboardController : AppController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}