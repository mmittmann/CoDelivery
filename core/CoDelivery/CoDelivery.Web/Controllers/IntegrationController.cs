using System.Web.Mvc;
using CoDelivery.Core.Repositories;
using CoDelivery.Web.Models;

namespace CoDelivery.Web.Controllers
{
    public class IntegrationController : Controller
    {
        private readonly IntegrationRepository _integrationRepository;

        public IntegrationController(IntegrationRepository integrationRepository)
        {
            _integrationRepository = integrationRepository;
        }

        public ActionResult Index()
        {
            var integrations = _integrationRepository.GetALot(i => i.User.Name == User.Identity.Name);

            return View(integrations);
        }

        public ActionResult Create(IntegrationModel model)
        {
            return null;
        }
    }
}