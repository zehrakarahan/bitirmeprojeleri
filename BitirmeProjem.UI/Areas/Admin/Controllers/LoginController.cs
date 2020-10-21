using System.Web.Mvc;
using System.Web.Security;
using BitirmeProjem.UI.Areas.Admin.Models;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.UI.Helpers;
using Enums = Core.Utilities.Enum.Enums;

namespace BitirmeProjem.UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _service;

        public LoginController(IUserService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(LoginVM model)
        {
            return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                string password = Helper.CreateMd5(model.Password);
                var user = _service.Get(x => x.UserName == model.UserName && x.Password == password).Entity;
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.ID+"-"+user.Name, model.Remember);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.Clear();
            model.Status = Enums.StatusEnum.Error;
            model.Message = "Giriş Başarısız";
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}