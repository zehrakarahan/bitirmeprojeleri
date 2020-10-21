using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.UI.Helpers;

namespace BitirmeProjem.UI.Controllers
{
    public class BaseController : Controller
    {
        private IUrunlerService urunlerService;
        private IKategorilerService _kategorilerService;
        public bool IsLogin { get; private set; }
        public int LoginUserId { get; private set; }
        public IUserService LoginUserEntity { get; private set; }
        public BaseController(IUrunlerService urunlerService)
        {
            this.urunlerService = urunlerService;
        }

        public BaseController(IKategorilerService kategorilerService)
        {
            _kategorilerService = kategorilerService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            if (Session["Kategoriler"] == null)
            {
                var kategoriler = _kategorilerService.GetList(x => true).Entity;
                var list = Helper.Categories(null, kategoriler);
                Session.Add("Kategoriler",list);
            }
            base.OnActionExecuting(filterContext);
        }

    }
}