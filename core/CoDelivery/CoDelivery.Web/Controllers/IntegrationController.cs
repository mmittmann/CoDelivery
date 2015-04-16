using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CoDelivery.Core.Entities;
using CoDelivery.Core.Infra.IntegrationSystems;
using CoDelivery.Web.Models;

namespace CoDelivery.Web.Controllers
{
    public class IntegrationController : AppController
    {
        private readonly CoDeliveryContext _context;

        public IntegrationController(CoDeliveryContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var user = _context.Users.GetByUserName(UserName);
            var integrations = new List<Integration>();

            if (user != null && user.Integrations != null)
                integrations = user.Integrations.ToList();

            return View(integrations.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            var integration = _context.Integrations.FirstOrDefault(i => i.Id == id);

            return View(integration);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            var integration = _context.Integrations.FirstOrDefault(i => i.Id == id);

            _context.Integrations.Remove(integration);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GetConfigDetails(int id)
        {
            var integration = _context.Integrations.GetById(id);

            if (integration.User.UserName != this.UserName)
                return Json(new { Success = false, Folders = false });

            var configs = integration.Settings;

            var integrationSystem = new DropBoxIntegration(configs);

            var folders = integration.GetFolders(integrationSystem, "/");

            return Json(new { Success = true, Folders = folders }, JsonRequestBehavior.AllowGet);
        }
    }
}