using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoDelivery.Core.Entities;
using CoDelivery.Web.Models;

namespace CoDelivery.Web.Controllers
{
    public class FtpController : AppController
    {
         private readonly CoDeliveryContext _context;

         public FtpController(CoDeliveryContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FtpModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var configurations = new Dictionary<string, string>
            {
                {"User", model.User},
                {"Password", model.Password},
                {"Host", model.Host},
                {"Port", model.Port ?? ""}
            };

            var integration = new Integration
            {
                IntegrationSystem = IntegrationSystem.Ftp,
                Name = model.Name,
                User = _context.Users.GetByUserName(UserName),
                Settings = configurations
            };

            _context.Integrations.Add(integration);

            _context.SaveChanges();

            return RedirectToAction("Index", "Integration");
        }
    }
}