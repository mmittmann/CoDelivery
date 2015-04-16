using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CoDelivery.Core.Entities;
using CoDelivery.Web.Models;

namespace CoDelivery.Web.Controllers
{
    public class DashboardController : AppController
    {
        private readonly CoDeliveryContext _context;

        public DashboardController(CoDeliveryContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var user = _context.Users.GetByUserName(UserName);

            var recipes = user.Recipes == null ? new List<Recipe>() : user.Recipes.ToList();
            var integrations = user.Integrations == null ? new List<Integration>() : user.Integrations.ToList();

            var dashboardModel = new DashboardModel
            {
                Recipes = new DashboardSpecificModel<Recipe>()
                {
                    List = recipes.ToList(),
                    Name = "Recipe",
                    Label = "Receitas"
                },
                Integrations = new DashboardSpecificModel<Integration>()
                {
                    List = integrations.ToList(),
                    Name = "Integration",
                    Label = "Integrações"
                }
            };

            return View(dashboardModel);
        }
    }
}