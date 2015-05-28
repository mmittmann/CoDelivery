using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using AutoMapper;
using CoDelivery.Core.Entities;
using CoDelivery.Core.Infra.Clients;
using CoDelivery.Core.Infra.IntegrationSystems;
using CoDelivery.Core.Migrations;
using CoDelivery.Web.Models;

namespace CoDelivery.Web.Controllers
{
    public class RecipeController : AppController
    {
        private readonly CoDeliveryContext _context;

        public RecipeController(CoDeliveryContext context)
        {
            Mapper.CreateMap<RecipeModel, Recipe>();
            Mapper.CreateMap<Recipe, RecipeModel>()
                .AfterMap(
                (src, dest) => dest.Integrations = src.IntegrationRecipes.Select(
                    ir => ir.Integration.IntegrationSystem.ToString())
                        .ToList());

            _context = context;
        }

        public ActionResult Index()
        {
            var recipesFromUser = _context.Recipes.Where(r => r.User.UserName == this.UserName).ToList();

            var recipesModel = Mapper.Map<List<Recipe>, List<RecipeModel>>(recipesFromUser);

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
        public ActionResult Create(RecipeModel recipeModel)
        {
            if (!ModelState.IsValid)
                return View(recipeModel);

            var recipe = Mapper.Map<RecipeModel, Recipe>(recipeModel);
            recipe.User = _context.Users.First(u => u.UserName == this.UserName);

            _context.Recipes.Add(recipe);

            foreach (var s in recipeModel.IntegrationSettings)
            {
                var integration = _context.Integrations.FirstOrDefault(i => i.Id == s.Key);
                var integrationRecipe = new IntegrationRecipe()
                {
                    Configurations = new Dictionary<string, string> { { "Folder", s.Value } },
                    Integration = integration,
                    Recipe = recipe
                };

                _context.IntegrationRecipes.Add(integrationRecipe);
            }


            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);

            if (recipe != null && recipe.User.UserName != this.UserName)
            {
                ModelState.AddModelError("", "Receita não pertence a este usuário");
                return View();
            }

            var recipeModel = Mapper.Map<Recipe, RecipeModel>(recipe);

            return View(recipeModel);
        }

        [HttpPost]
        public ActionResult Delete(RecipeModel recipeModel)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == recipeModel.Id);

            if (recipe != null && recipe.User.UserName != this.UserName)
            {
                ModelState.AddModelError("", "Receita não pertence a este usuário");
                return View();
            }

            var integrationRecipes = _context.IntegrationRecipes.Where(r => r.Recipe.Id == recipe.Id);
            foreach (var ir in integrationRecipes)
            {
                _context.IntegrationRecipes.Remove(ir);
            }
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Run(int idRecipe)
        {
            var recipe = _context.Recipes.First(r => r.Id == idRecipe);
            var integrationRecipes = recipe.IntegrationRecipes;
            if (integrationRecipes.Count > 2)
                throw new Exception("Algo não saiu como deveria.");

            var isFirstCycle = true;

            foreach (var ir in integrationRecipes)
            {
                var integrationManager = new IntegrationSystemFactory().Build(ir.Integration.IntegrationSystem,
                    ir.Integration.Settings);

                if (isFirstCycle)
                {
                    var files = integrationManager.GetFiles(ir.Configurations["Folder"]);
                    foreach (var file in files)
                    {
                        var completedPath = string.Format(@"C:\CoDelivery\{0}\{1}", UserName, file.Key);
                        var path = completedPath.Remove(completedPath.LastIndexOf('/') + 1);

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        System.IO.File.Create(completedPath).Close();

                        System.IO.File.WriteAllBytes(completedPath, file.Value);
                    }

                    isFirstCycle = false;
                }
                else
                {
                    var pathName = string.Format(@"C:\CoDelivery\{0}", UserName);
                    DirSearch(pathName, integrationManager, ir);
                }
            }

            return RedirectToAction("Index");
        }

        static void DirSearch(string sDir, IIntegrationSystem integrationManager, IntegrationRecipe ir)
        {
            try
            {
                foreach (var d in Directory.GetDirectories(sDir))
                {
                    foreach (var f in Directory.GetFiles(d))
                    {
                        var fileContent = System.IO.File.ReadAllBytes(f);
                        integrationManager.UploadFile(f.Split('\\').Last(), ir.Configurations["Folder"], fileContent);
                    }
                    DirSearch(d, integrationManager, ir);
                }
            }
            catch
            {
                //Do nothing
            }
        }
    }
}