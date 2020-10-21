using System.Web.Mvc;
using System.Web.Script.Serialization;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.UI.Helpers;
using BitirmeProjem.UI.Models.VM;
using Core.Utilities.Enum;
using System;
using System.Web;

namespace BitirmeProjem.UI.Controllers
{
    public class UrunlerController : BaseController
    {
        IKategorilerService _kategorilerService;
        IUrunlerService _urunlerService;
        IYorumlarService _yorumlarService;
        IUyelerService _uyelerService;
        
        public UrunlerController(IKategorilerService kategorilerService,IUrunlerService urunlerService,IYorumlarService yorumlarService,IUyelerService uyelerService) :base(kategorilerService)
        {
            _kategorilerService = kategorilerService;
            _urunlerService = urunlerService;
            _yorumlarService = yorumlarService;
            _uyelerService = uyelerService;
            
        }
       
        // GET: Urunler
        public ActionResult Index()
        {
         
            return View();   
        }
        
        public ActionResult UrunDetay(int id)
        {
            var urun = _urunlerService.Get(x => x.ID == id).Entity;//urunlerin listesini bulmak icin
            var yorumlar = _yorumlarService.GetList(x => x.UrunID == urun.ID && x.Onay==true).Entity;
            ViewBag.Yorumlar = yorumlar;
            return View(urun);
        }
        public ActionResult Index(int id)
        {
            return View();
        }
        [HttpPost]
        public JsonResult YorumYap(string yorum,int urunid,int puan)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var uyeID = js.Deserialize<Uyeler>(Session["Uye"].ToString()).ID;
            var urunPuan = Convert.ToInt16(puan);
            if(yorum==null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);   
            }
            _yorumlarService.Add(new Yorumlar { UyeID = Convert.ToInt32(uyeID), UrunID = urunid, Yorum = yorum,Puan= urunPuan, Onay=false});
            return Json(false,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Cookie_Ekleme(int id)
        {
            var urun = _urunlerService.Get(x => x.ID == id).Entity;
            HttpCookie cookieVisitor = new HttpCookie("urun_resmi",urun.KapakResmi);
            Response.Cookies.Add(cookieVisitor);
            HttpCookie cookieVisitor2 = new HttpCookie("urun_adi", urun.Adi);
            Response.Cookies.Add(cookieVisitor2);
            HttpCookie cookieVisitor3 = new HttpCookie("urun_fiyati", urun.Fiyat.ToString());
            Response.Cookies.Add(cookieVisitor3);
            return RedirectToAction("getCookie");
        }
        public ActionResult getCookie()
        {
            HttpCookie urunid = Request.Cookies.Get("urun_resmi");
            string urunid2 = urunid.Value;
            ViewBag.UrunResmi = urunid2;
            HttpCookie urunadi = Request.Cookies.Get("urun_adi");
            string urunadi2 = urunadi.Value;
            ViewBag.UrunAdi = urunadi2;
            HttpCookie urunfiyat = Request.Cookies.Get("urun_fiyati");
            string urunfiyat2 = urunfiyat.Value;
             ViewBag.UrunFiyati = urunfiyat2;
            return View();
        }
    }
}