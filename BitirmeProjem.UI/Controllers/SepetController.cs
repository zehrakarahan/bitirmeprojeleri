using BitirmeProjem.Business.Abstract;
using BitirmeProjem.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BitirmeProjem.UI.Controllers
{
    public class SepetController : BaseController
    {
        // GET: Sepet
        IKategorilerService _kategorilerService;
        IUrunlerService _urunlerService;
        List<SepetUrun> sepet;
        IKuponlarService _kuponService;

        public SepetController(IKategorilerService kategorilerService, IUrunlerService urunlerService, IKuponlarService kuponService) : base(kategorilerService)
        {
            _kategorilerService = kategorilerService;
            _urunlerService = urunlerService;
            _kuponService = kuponService;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SepeteEkle(int urunID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (Session["Sepet"] == null)
            {
                sepet = new List<SepetUrun>();
                var urunler = js.Serialize(sepet);
                Session.Add("Sepet", urunler);
            }
            var urun = _urunlerService.Get(x => x.ID == urunID).Entity;
            
            var sepetim = js.Deserialize<List<SepetUrun>>(Session["Sepet"].ToString());


            if (sepetim.FirstOrDefault(x => x.ID == urunID) != null)
            {
                var k = sepetim.FirstOrDefault(x => x.ID == urunID);
                k.Adet++;
            }
            else
            {
                sepetim.Add(new SepetUrun { ID = urun.ID, UrunAdi = urun.Adi, Fiyat = urun.Fiyat, UrunResim = urun.KapakResmi, UrunUrl = urun.SeoUrl, Adet = 1 });
            }
            Session["Sepet"] = js.Serialize(sepetim);
            return Json("Eklendi");
        }
        [HttpGet]
        public JsonResult SepetGetir()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (Session["Sepet"] != null)
            {
                var sepetim = js.Deserialize<List<SepetUrun>>(Session["Sepet"].ToString());
                var toplamUrun = sepetim.Count;
                var toplamFiyat = sepetim.Sum(x => x.Fiyat * x.Adet);

                return Json(new { urunler = sepetim, toplamUrun, toplamFiyat }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { toplamUrun = 0, toplamFiyat = 0 }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SepetDetay()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (Session["Sepet"] != null)
            {
                var sepetim = js.Deserialize<List<SepetUrun>>(Session["Sepet"].ToString());
                var toplamFiyat = sepetim.Sum(x => x.Fiyat * x.Adet);

                HttpCookie cookieVisitor = new HttpCookie("urun_toplam_fiyati", toplamFiyat.ToString());
                Response.Cookies.Add(cookieVisitor);
                HttpCookie urunid = Request.Cookies.Get("urun_toplam_fiyati");
                string urunid2 = urunid.Value;
                ViewBag.Tutardegeri = urunid2;
                return View(sepetim);
            }
            return View();
        }
        [HttpPost]
        public JsonResult Kupon_kismi(string kupon)
        {
            var tarih = System.DateTime.Now;
            var kupon_degerleri = _kuponService.Get(x => x.Kodu == kupon && x.BitisTarihi >= tarih).Entity;
            if (kupon_degerleri != null)
            {
                return Json(kupon_degerleri.Oran);
            }
            return Json("0");
        }
    }
}