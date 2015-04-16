using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoDelivery.Core.Entities;
using CoDelivery.Core.Infra.Clients;
using CoDelivery.IntegrationTests;

namespace CoDelivery.Web.Controllers
{
    public class DropboxController : AppController
    {
        private readonly CoDeliveryContext _context;
        private DropBoxClient _dropBoxClient;

        public DropboxController(DropBoxClient dropBoxClient, CoDeliveryContext context)
        {
            _context = context;
            _dropBoxClient = dropBoxClient;
        }

        public ActionResult Index()
        {
            var integrationsOfUser = _context.Users.GetByUserName(this.UserName).Integrations ?? new List<Integration>();

            if (integrationsOfUser.Count > 0 && integrationsOfUser.Any(i => i.IntegrationSystem == IntegrationSystem.DropBox))
                return RedirectToAction("Create", "Integration");

            ViewBag.Url = _dropBoxClient.GetUrlToRequestToken(ConfigurationManager.AppSettings["urlCallbackDropBoxAuth"]);

            Session["dropboxObject"] = Session["dropboxObject"] ?? _dropBoxClient;

            return View();
        }

        public ActionResult Confirm()
        {
            _dropBoxClient = (DropBoxClient)Session["dropboxObject"] ?? new DropBoxClient();

            _dropBoxClient.GetAccessToken();

            var apiSecret = _dropBoxClient.ApiSecret;
            var accessToken = _dropBoxClient.AccessToken;

            var user = _context.Users.GetByUserName(UserName);

            var information = _dropBoxClient.GetInformation();

            var integration = new Integration()
            {
                Name = "Conta - " + information.Name + "(" + information.Email + ")",
                IntegrationSystem = IntegrationSystem.DropBox,
                User = user,
                Settings = new Dictionary<string, string>() { { "apiSecret", apiSecret }, { "accessToken", accessToken } }
            };

            _context.Integrations.Add(integration);
            _context.SaveChanges();

            return RedirectToAction("Index", "Integration");
        }

    }
}