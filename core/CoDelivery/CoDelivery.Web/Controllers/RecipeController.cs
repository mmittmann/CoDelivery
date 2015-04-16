using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CoDelivery.Core.Entities;
using CoDelivery.Core.Infra.Clients;
using CoDelivery.Web.Models;

namespace CoDelivery.Web.Controllers
{
    public class RecipeController : AppController
    {
        private readonly CoDeliveryContext _context;

        public RecipeController(CoDeliveryContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var recipesFromUser = _context.Recipes.Where(r => r.User.Name == this.UserName).ToList();

            Mapper.CreateMap<List<RecipeModel>, List<Recipe>>();
            var recipesModel = Mapper.Map<List<RecipeModel>>(recipesFromUser);

            return View(recipesModel);
        }

        public ActionResult Create()
        {
            Mapper.CreateMap<Integration, IntegrationModel>();

            var integrations = _context.Integrations.Where(i => i.User.UserName == UserName).ToList();

            var mappedIntegrations = Mapper.Map<List<Integration>, List<IntegrationModel>>(integrations);

            ViewBag.Integrations = mappedIntegrations;


            return View();
        }

        [HttpPost]
        public ActionResult Create(RecipeModel recipe)
        {
            return View();
        }
    }
}