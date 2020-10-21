using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.UI.Areas.Admin.Models;
using BitirmeProjem.UI.Areas.Admin.Models.VM;
using BitirmeProjem.UI.Helpers;
using Core.Entities;
using Core.Helpers;
using System.Linq;

namespace BitirmeProjem.UI.Areas.Admin.Controllers
{
    public class YorumlarController : Controller
    {
        private IYorumlarService _yorumlarService;

        public YorumlarController(IYorumlarService yorumlarService)
        {
            _yorumlarService = yorumlarService;
        }

        // GET: Admin/Yorumlar
        public ActionResult Index()
        {
            var yorum = _yorumlarService.GetList(x => true).Entity.ToList();
            ViewBag.List = yorum;
            var model = new BaseModel();
            Helper.SetModelTempData(this, "Message", model);
            return View(model);
        }
    

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var entity = _yorumlarService
                .Get(x => x.ID == id).Entity;
            if (entity != null)
            {
                _yorumlarService.Delete(x => x.ID == id);
                return Json(new { Status = "success", Message = "Silindi" });
            }
            else
            {
                return Json(new { Status = "error", Message = "Bir hata oluştu" });
            }
        }

        public ActionResult Duzenle(int id)
        {
            var yorum = _yorumlarService.Get(x => x.ID == id).Entity;
            var model = Mapper.Map<YorumlarVM>(yorum);
            return View(model);
        }
        [HttpPost]
        public ActionResult Duzenle(YorumlarVM model)
        {
            var yorum = _yorumlarService.Get(x => x.ID == model.ID).Entity;
            yorum.Onay = model.Onay;
            _yorumlarService.Update(yorum);
            Helper.setTempData(this, "Message", true, "Bilgiler Güncellendi.");
            return RedirectToAction("Index");
        }
    }
}