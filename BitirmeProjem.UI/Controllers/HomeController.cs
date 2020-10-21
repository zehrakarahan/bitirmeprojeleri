using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjem.Business.Abstract;
using System.Web.Script.Serialization;
using BitirmeProjem.Entities.Concrete;

namespace BitirmeProjem.UI.Controllers
{
    public class HomeController : BaseController
    {
        IUrunlerService _urunlerService;
        IKategorilerService _kategorilerService;
        IUyelerService _uyelerService;
        //IFavorilerService _favorilerService;
        public HomeController(IKategorilerService kategorilerService,IUrunlerService urunlerService,IUyelerService uyelerService):base(kategorilerService)
        {
            _urunlerService = urunlerService;
            _kategorilerService = kategorilerService;
            _uyelerService = uyelerService;
            //_favorilerService = favorilerService;
        }
        
        // GET: Home
        public ActionResult Index()
        {
           
            var kadinAyakkabiID = _kategorilerService.Get(x => x.Adi == "Kadın Ayakkabı").Entity?.ID;
            var kadinAyakkabilari=_urunlerService.GetList(x => x.KategoriID == kadinAyakkabiID).Entity.ToList();
            var erkekAyakkabiID = _kategorilerService.Get(x => x.Adi == "Erkek Ayakkabı").Entity.ID;
            var erkekAyakkabilari = _urunlerService.GetList(x => x.KategoriID == erkekAyakkabiID).Entity.ToList();
            var cocukAyakkabiID = _kategorilerService.Get(x => x.Adi == "Çocuk Ayakkabı").Entity.ID;
            var cocukAyakkabilari = _urunlerService.GetList(x => x.KategoriID == cocukAyakkabiID).Entity.ToList();
            ViewBag.KadinAyakkabilari = kadinAyakkabilari;
            ViewBag.ErkekAyakkabilari = erkekAyakkabilari;
            ViewBag.CocukAyakkabilari = cocukAyakkabilari;
            return View();
        }
        [HttpPost]
        public JsonResult FavorilereEkle(int id)
        {
            var urunId = _urunlerService.Get(x => x.ID == id).Entity.ID;
            JavaScriptSerializer js = new JavaScriptSerializer();
            var uyeID = js.Deserialize<Uyeler>(Session["Uye"].ToString()).ID;
            var uye = _uyelerService.Get(x => x.ID == uyeID).Entity;

            //_favorilerService.Add(new Favoriler { UyeID=uyeID,UrunID= urunId});
            return Json(false,JsonRequestBehavior.AllowGet); 

        }
        public ActionResult Favorilistele()
        {
            //var tablo = _favorilerService.GetAll().Entity.ToList();
            
            return View();
        }
        
      


    }
}