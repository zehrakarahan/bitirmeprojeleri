using System.Web.Mvc;
using System.Web.Script.Serialization;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.UI.Helpers;
using BitirmeProjem.UI.Models.VM;
using Core.Utilities.Enum;

namespace BitirmeProjem.UI.Controllers
{
    public class UyeController : BaseController
    {
        private IUyelerService _uyelerService;
        public UyeController(IKategorilerService kategorilerService, IUyelerService uyelerService) : base(kategorilerService)
        {

            _uyelerService = uyelerService;
        }
        // GET: Uye
        public ActionResult UyeOl()
        {
            if (Session["Uye"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult UyeOl(UyeOl model)
        {
            if (ModelState.IsValid)
            {
                var entity = AutoMapper.Mapper.Map<Uyeler>(model);
                entity.Sifre = Helper.CreateMd5(entity.Sifre);
                var result = _uyelerService.Add(entity);
                if (result.Status.Status == Enums.StatusEnum.Successful)
                {
                    var uyeBilgileri = AutoMapper.Mapper.Map<UyeOl>(result.Entity);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Session.Add("Uye", js.Serialize(uyeBilgileri));
                    return RedirectToAction("KayitTamamlandi");
                }
                else
                {
                    if (result.Status.Exception.InnerException.InnerException.Message.Contains("UNIQUE KEY"))
                    {
                        model.Mesaj = "Bu mail adresi kullanılıyor";
                    }
                }
            }
            return View(model);
        }
        public ActionResult UyeGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeGiris(UyeGiris model)
        {
            if (ModelState.IsValid)
            {
                var sifre = Helper.CreateMd5(model.Sifre);
                var uye = _uyelerService.Get(x => x.Email == model.Email && x.Sifre == sifre).Entity;
                if (uye == null)
                {
                    model.Mesaj = "Giriş bilgileri hatalı";
                    return View(model);
                }

                var uyeBilgileri = AutoMapper.Mapper.Map<UyeOl>(uye);
                JavaScriptSerializer js = new JavaScriptSerializer();
                Session.Add("Uye", js.Serialize(uyeBilgileri));
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public ActionResult KayitTamamlandi()
        {
            if (Session["Uye"] == null)
            {
                return RedirectToAction("UyeOl");
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            var uye = js.Deserialize<Uyeler>(Session["Uye"].ToString());
            return View(uye);
        }

        public ActionResult CikisYap()
        {
            if (Session["Uye"] != null)
            {
                Session["Uye"] = null;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}