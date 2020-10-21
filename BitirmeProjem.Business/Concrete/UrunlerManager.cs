using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.DataAccess.Abstract;
using BitirmeProjem.Entities.Concrete;
using Core.Utilities.Enum;
using BitirmeProjem.Business.ReturnData;
using Core.Entities;

namespace BitirmeProjem.Business.Concrete
{
    public class UrunlerManager : IUrunlerService
    {
        private readonly IUrunlerDal _urunlerDal;
        public UrunlerManager(IUrunlerDal urunlerDal)
        {
            _urunlerDal = urunlerDal;
        }
        public StatusData<IList<Urunler>> GetList(Expression<Func<Urunler, bool>> filter)
        {
            var returnData = new StatusData<IList<Urunler>>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _urunlerDal.GetEntities(filter);
                if (returnData.Entity.Count == 0)
                {
                    returnData.Status.Message = "Veri Bulunamadı";
                    returnData.Status.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Status.Message = "İşlem Başarılı";
                    returnData.Status.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Status.Message = "Hata Oluştu";
                returnData.Status.Exception = ex;
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }
        public StatusData<Urunler> Get(Expression<Func<Urunler, bool>> filter)
        {
            var returnData = new StatusData<Urunler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _urunlerDal.Get(filter);

                if (returnData.Entity == null)
                {
                    returnData.Status.Message = "Veri Bulunamadı";
                    returnData.Status.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Status.Message = "İşlem Başarılı";
                    returnData.Status.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Status.Message = "Hata Oluştu";
                returnData.Status.Exception = ex;
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }
        public StatusData<Urunler> Add(Urunler entity)
        {
            var returnData = new StatusData<Urunler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _urunlerDal.Add(entity);

                returnData.Status.Message = "İşlem Başarılı";
                returnData.Status.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Status.Message = "Hata Oluştu";
                returnData.Status.Exception = ex;
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }
        public StatusData<Urunler> Update(Urunler entity)
        {
            var returnData = new StatusData<Urunler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _urunlerDal.Update(entity);

                returnData.Status.Message = "İşlem Başarılı";
                returnData.Status.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Status.Message = "Hata Oluştu";
                returnData.Status.Exception = ex;
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }
        public StatusData<Urunler> Delete(Expression<Func<Urunler, bool>> filter)
        {
            var returnData = new StatusData<Urunler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                var entity = _urunlerDal.Get(filter);
                _urunlerDal.Delete(entity);
                returnData.Status.Message = "İşlem Başarılı";
                returnData.Status.Status = Enums.StatusEnum.Successful;
            }
            catch (Exception ex)
            {
                returnData.Status.Message = "Hata Oluştu";
                returnData.Status.Exception = ex;
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }

        public StatusData<PageDataTable> GetEntitiesForDt(GenericFilter<Urunler> filter)
        {
            var returnData = new StatusData<PageDataTable>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _urunlerDal.GetEntitiesForDt(filter);
                if (returnData.Entity == null)
                {
                    returnData.Status.Message = "Veri Bulunamadı";
                    returnData.Status.Status = Enums.StatusEnum.EmptyData;
                }
                else
                {
                    returnData.Status.Message = "İşlem Başarılı";
                    returnData.Status.Status = Enums.StatusEnum.Successful;
                }
            }
            catch (Exception ex)
            {
                returnData.Status.Message = "Hata Oluştu";
                returnData.Status.Exception = ex;
                returnData.Status.Status = Enums.StatusEnum.Error;
            }
            return returnData;
        }
    }
}
