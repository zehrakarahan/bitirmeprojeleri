using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.UI.Helpers;

namespace BitirmeProjem.UI.Areas.Admin.Controllers
{
    public class KategorilerController : Controller
    {
        private IKategorilerService _kategorilerService;

        public KategorilerController(IKategorilerService kategorilerService)
        {
            _kategorilerService = kategorilerService;
        }

       
        public ActionResult Index()
        {


            return View();
        }
        [HttpPost]
        public int KategoriEkle(string adi, int ustID)
        {
            var kategori = new Kategoriler { Adi = adi };
            if (ustID!=0)
            {
                kategori.UstID = ustID;
            }

            kategori.SeoUrl = kategori.Adi.ClearUrl();
            _kategorilerService.Add(kategori);
            Session.Clear();
            return kategori.ID;
        }
        [HttpPost]
        public void KategoriAdiDegistir(string adi,int id)
        {
            var kategori = _kategorilerService.Get(x => x.ID == id).Entity;
            kategori.Adi = adi;
            kategori.SeoUrl = kategori.Adi.ClearUrl();
            _kategorilerService.Update(kategori);
            Session.Clear();
        }

        public void KategoriSil(int id)
        {
            _kategorilerService.Delete(x => x.ID == id);
            Session.Clear();
        }

        public JsonResult KategorileriGetir()
        {
            var list = _kategorilerService.GetList(x => true).Entity;
            var js = Helper.Categories(null, list);
            var list2 = new List<TreeViewKategori>();
            list2.Add(new TreeViewKategori { text = "Kategoriler", id = "0",children = js});
            return Json(list2, JsonRequestBehavior.AllowGet);
        }
      
    }
}
