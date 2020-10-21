using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.UI.Areas.Admin.Models.VM;
using BitirmeProjem.UI.Helpers;
using Core.Entities;
using Core.Helpers;
using Core.Utilities.Enum;

namespace BitirmeProjem.UI.Areas.Admin.Controllers
{
    public class KuponlarController : BaseController
    {
        private IKuponlarService _kuponlarService;

        public KuponlarController(IKuponlarService kuponlarService)
        {
            _kuponlarService = kuponlarService;
        }

        // GET: Admin/Kuponlar
        public ActionResult Index()
        {
            var list = _kuponlarService.GetList(x => true).Entity.ToList();
            ViewBag.List = list;
            return View();
        }
        public ActionResult Add(int id = 0)
        {
            var model = new KuponlarVM();
            if (id > 0)
            {
                var entity = _kuponlarService.Get(x => x.ID == id).Entity;
                model = Mapper.Map<KuponlarVM>(entity);
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(KuponlarVM model)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Kuponlar>(model);
                
                if (entity.ID == 0)
                {
                   var kayit= _kuponlarService.Add(entity);
                    model = new KuponlarVM
                    {
                        Status =kayit.Status.Status,
                        Message = kayit.Status.Message
                    };
                    ModelState.Clear();
                    return View(model);
                }
                _kuponlarService.Update(entity);
                Helper.setTempData(this, "Message", true, "Bilgiler Güncellendi.");
                return RedirectToAction("Index");
            }
            model.Status = Enums.StatusEnum.Error;
            model.Message = "Kayıt yapılamadı.Lütfen bilgileri hatasız girdiğinizden emin olun";
            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var entity = _kuponlarService.Get(x => x.ID == id).Entity;
            if (entity != null)
            {
                _kuponlarService.Delete(x => x.ID == id);
                return Json(new { Status = "success", Message = "Silindi" });
            }
            else
            {
                return Json(new { Status = "error", Message = "Bir hata oluştu" });
            }
        }
    }
}