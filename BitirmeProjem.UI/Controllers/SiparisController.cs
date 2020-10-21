using BitirmeProjem.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.UI.Areas.Admin.Models.VM;
using BitirmeProjem.UI.Helpers;
using Core.Entities;
using Core.Helpers;
using Core.Utilities.Enum;
using BitirmeProjem.UI.ViewModel;
using BitirmeProjem.UI.Models;
using System.Web.Script.Serialization;

namespace BitirmeProjem.UI.Controllers
{
    public class SiparisController : BaseController
    {
        IKategorilerService _kategorilerService;
        IUrunlerService _urunlerService;
        IKuponlarService _kuponService;
        ISehirlerService _sehirlerService;
        IIlcelerService _ilcelerService;
        IUyelerService _uyelerService;
        IUyeAdreService _uyeadreService;
        public SiparisController(IKategorilerService kategorilerService, IUrunlerService urunlerService, IKuponlarService kuponService, ISehirlerService sehirlerService, IIlcelerService ilcelerService, IUyelerService uyelerService, IUyeAdreService uyeadreService) : base(kategorilerService)
        {
            _kategorilerService = kategorilerService;
            _uyelerService = uyelerService;
            _urunlerService = urunlerService;
            _kuponService = kuponService;
            _sehirlerService = sehirlerService;
            _ilcelerService = ilcelerService;
            _uyeadreService = uyeadreService;

        }
        // GET: Siparis

        public ActionResult AdresList()
        {
            if (Session["Uye"] == null)
            {
                return RedirectToAction("UyeGiris", "Uye");

            }

            SehirViewModel model = new SehirViewModel();
            List<Sehirler> sehirlist = _sehirlerService.GetAll().Entity.ToList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var uyeID = js.Deserialize<Uyeler>(Session["Uye"].ToString()).ID;
            var uye = _uyelerService.Get(x => x.ID == uyeID).Entity;

            HttpCookie cookieVisitor = new HttpCookie("adi", uye.Adi);
            Response.Cookies.Add(cookieVisitor);
            HttpCookie kisiadi = Request.Cookies.Get("adi");
            string kisiadi2 = kisiadi.Value;
            ViewBag.kisiadi = kisiadi2;


            HttpCookie cookieVisitor2 = new HttpCookie("soyadi", uye.Soyadi);
            Response.Cookies.Add(cookieVisitor2);
            HttpCookie kisisoyadi = Request.Cookies.Get("soyadi");
            string kisisoyadi2 = kisisoyadi.Value;
            ViewBag.kisisoyadi = kisisoyadi2;

            ViewBag.Kullanici = _uyelerService.Get(x => x.ID == uyeID).Entity;
            List<UyeAdres> uyeadresList = _uyeadreService.GetList(x => x.UyeID == uyeID).Entity.ToList();

            List<UyeAdres> baslikList = _uyeadreService.GetList(x => x.UyeID == uyeID).Entity.ToList();
            model.BaslikList = (from k in baslikList
                                select new SelectListItem
                                {
                                    Text = k.Baslik,
                                    Value = k.ID.ToString()
                                }).ToList();
            model.SehirList = (from s in sehirlist
                               select new SelectListItem
                               {
                                   Text = s.Adi,
                                   Value = s.ID.ToString()
                               }).ToList();
            model.AdresList = (from k in uyeadresList
                               select new SelectListItem
                               {
                                   Text = k.Adres,
                                   Value = k.ID.ToString()
                               }).ToList();

            model.SehirList.Insert(0, new SelectListItem { Text = "Seciniz", Value = "", Selected = true });
            model.AdresList.Insert(0, new SelectListItem { Text = "Seciniz", Value = "", Selected = true });
            model.BaslikList.Insert(0, new SelectListItem { Text = "Seciniz", Value = "", Selected = true });
            return View(model);



        }
     

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult IlceList(int id)
        {

            List<Ilceler> ilceListe = _ilcelerService.GetList(f => f.SehirID == id).Entity.ToList();

            List<SelectListItem> itemList = (from s in ilceListe
                                             select new SelectListItem
                                             {
                                                 Text = s.Adi,
                                                 Value = s.ID.ToString()
                                             }).ToList();
            return Json(itemList, JsonRequestBehavior.AllowGet);
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Deneme(string baslik, int ilId, int IlceId, string adres)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var uyeID = js.Deserialize<Uyeler>(Session["Uye"].ToString()).ID;
            ViewBag.Uyeadsoyad = _uyelerService.Get(x => x.ID == uyeID).Entity;
            ViewBag.Adresler = _uyeadreService.GetList(x => x.UyeID == uyeID).Entity.ToList();

            _uyeadreService.Add(new UyeAdres { UyeID = Convert.ToInt32(uyeID), Baslik = baslik, SehirID = ilId, IlceID = IlceId, Adres = adres });
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SonucKismi(int Id)
        {
            
                if (Session["Uye"] == null)
                {
                    return RedirectToAction("UyeGiris", "Uye");

                }
                var deger = _uyeadreService.Get(x => x.ID == Id).Entity.Adres;
                ViewBag.uyeadres = deger;
                JavaScriptSerializer js = new JavaScriptSerializer();
                var uyeID = js.Deserialize<Uyeler>(Session["Uye"].ToString()).ID;
                var uye = _uyelerService.Get(x => x.ID == uyeID).Entity;

                HttpCookie cookieVisitor = new HttpCookie("adi", uye.Adi);
                Response.Cookies.Add(cookieVisitor);
                HttpCookie kisiadi = Request.Cookies.Get("adi");
                string kisiadi2 = kisiadi.Value;
                ViewBag.kisiadi = kisiadi2;


                HttpCookie cookieVisitor2 = new HttpCookie("soyadi", uye.Soyadi);
                Response.Cookies.Add(cookieVisitor2);
                HttpCookie kisisoyadi = Request.Cookies.Get("soyadi");
                string kisisoyadi2 = kisisoyadi.Value;
                ViewBag.kisisoyadi = kisisoyadi2;

                if (Session["Sepet"] != null)
                {
                    var sepetim = js.Deserialize<List<SepetUrun>>(Session["Sepet"].ToString());
                    var toplamFiyat = sepetim.Sum(x => x.Fiyat * x.Adet);

                    HttpCookie cookieVisitor3 = new HttpCookie("urun_toplam_fiyati", toplamFiyat.ToString());
                    Response.Cookies.Add(cookieVisitor3);
                    HttpCookie urunid = Request.Cookies.Get("urun_toplam_fiyati");
                    string urunid2 = urunid.Value;
                    ViewBag.Tutardegeri = urunid2;
                    return View(sepetim);
                }
            
          
            return View();
        }

        public ActionResult Sonuc(string adres)
        {
            
                if (Session["Uye"] == null)
                {
                    return RedirectToAction("UyeGiris", "Uye");

                }
                ViewBag.uyeadres = adres;
                JavaScriptSerializer js = new JavaScriptSerializer();
                var uyeID = js.Deserialize<Uyeler>(Session["Uye"].ToString()).ID;
                var uye = _uyelerService.Get(x => x.ID == uyeID).Entity;

                HttpCookie cookieVisitor = new HttpCookie("adi", uye.Adi);
                Response.Cookies.Add(cookieVisitor);
                HttpCookie kisiadi = Request.Cookies.Get("adi");
                string kisiadi2 = kisiadi.Value;
                ViewBag.kisiadi = kisiadi2;


                HttpCookie cookieVisitor2 = new HttpCookie("soyadi", uye.Soyadi);
                Response.Cookies.Add(cookieVisitor2);
                HttpCookie kisisoyadi = Request.Cookies.Get("soyadi");
                string kisisoyadi2 = kisisoyadi.Value;
                ViewBag.kisisoyadi = kisisoyadi2;

                if (Session["Sepet"] != null)
                {
                    var sepetim = js.Deserialize<List<SepetUrun>>(Session["Sepet"].ToString());
                    var toplamFiyat = sepetim.Sum(x => x.Fiyat * x.Adet);

                    HttpCookie cookieVisitor3 = new HttpCookie("urun_toplam_fiyati", toplamFiyat.ToString());
                    Response.Cookies.Add(cookieVisitor3);
                    HttpCookie urunid = Request.Cookies.Get("urun_toplam_fiyati");
                    string urunid2 = urunid.Value;
                    ViewBag.Tutardegeri = urunid2;
                    return View(sepetim);
                }
            return View();
        }




    }
}