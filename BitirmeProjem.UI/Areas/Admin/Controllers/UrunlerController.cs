using System.Web.Mvc;
using AutoMapper;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.UI.Areas.Admin.Models;
using BitirmeProjem.UI.Areas.Admin.Models.VM;
using BitirmeProjem.UI.Helpers;
using Core.Entities;
using Core.Helpers;
using Core.Utilities.Enum;
using System.Linq;


namespace BitirmeProjem.UI.Areas.Admin.Controllers
{
    public class UrunlerController : BaseController
    {
        public string folderPath = "Urunler";
        private readonly IUrunlerService _urunlerService;

        public UrunlerController(IUrunlerService urunlerService)
        {
            _urunlerService = urunlerService;
        }

        public ActionResult Index()
        {
            var liste = _urunlerService.GetList(x => true).Entity;
            ViewBag.List = liste.ToList();
            var model = new BaseModel();
            Helper.SetModelTempData(this, "Message", model);
            return View(model);
        }

        public ActionResult Add(int id = 0)
        {
            var model = new UrunlerVM();
            if (id > 0)
            {
                var entity = _urunlerService.Get(x => x.ID == id).Entity;
                model = Mapper.Map<UrunlerVM>(entity);
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(UrunlerVM model)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Urunler>(model);
                entity.SeoUrl = model.Adi.ClearUrl();
                if (model.File?.ContentLength > 0)
                {
                    if (!string.IsNullOrEmpty(model.KapakResmi))
                    {
                        ImageHelper.Delete(model.KapakResmi, folderPath);
                    }
                    var fileName = model.File.FileName;
                    ImageHelper.Upload(model.File, folderPath);
                    entity.KapakResmi = fileName;
                }
                if (entity.ID == 0)
                {
                    //entity.Goruntulenme = 1;
                    _urunlerService.Add(entity);
                    model = new UrunlerVM
                    {
                        Status = Enums.StatusEnum.Successful,
                        Message = "Kayıt Edildi"
                    };
                    ModelState.Clear();
                    return View(model);
                }
                _urunlerService.Update(entity);
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
            var entity = _urunlerService.Get(x => x.ID == id).Entity;
            if (entity != null)
            {
                Helper.DeleteFile(folderPath, entity.KapakResmi);
                _urunlerService.Delete(x => x.ID == id);
                return Json(new { Status = "success", Message = "Silindi" });
            }
            else
            {
                return Json(new { Status = "error", Message = "Bir hata oluştu" });
            }
        }
    }
}