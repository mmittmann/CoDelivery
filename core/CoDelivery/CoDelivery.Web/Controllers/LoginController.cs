using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CoDelivery.Core.Entities;
using CoDelivery.Web.Models;
using Microsoft.Owin.Security;

namespace CoDelivery.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly CoDeliveryContext _context;

        public LoginController(CoDeliveryContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel userModel)
        {
            if (!ModelState.IsValid)
                return View(userModel);

            var user = _context.Users.FirstOrDefault(u => u.UserName == userModel.User && u.Password == userModel.Password);

            if (user != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName)
                }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);

                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError("User", "Usuário ou senha não conferem.");
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpModel suModel)
        {
            if (!ModelState.IsValid)
                return View(suModel);

            Mapper.CreateMap<SignUpModel, User>().ForMember(m => m.UserName, a => a.MapFrom(mf => mf.User));
            var user = Mapper.Map<User>(suModel);

            _context.Users.Add(user);
            _context.SaveChanges();

            ViewBag.Message = new { Type = "Success", Message = "Cadastrado com sucesso!" };

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Index");
        }


    }
}