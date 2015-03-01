using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using CoDelivery.Core.Entities;
using CoDelivery.Core.Repositories;
using CoDelivery.Web.Models;

namespace CoDelivery.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserRepository _repository;

        public LoginController(UserRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel userModel)
        {
            var user = _repository.GetSpecific(u => u.UserName == userModel.User && u.Password == userModel.Password);

            if (user != null)
            {
                Membership.ValidateUser(userModel.User, userModel.Password);

                return RedirectToAction("Index");
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
            Mapper.CreateMap<SignUpModel, UserEntity>().ForMember(m => m.UserName, a => a.MapFrom(mf => mf.User));
            var user = Mapper.Map<UserEntity>(suModel);

            _repository.Save(user);

            ViewBag.Message = new { Type = "Success", Message = "Cadastrado com sucesso!" };

            return RedirectToAction("Index");
        }

        
    }
}