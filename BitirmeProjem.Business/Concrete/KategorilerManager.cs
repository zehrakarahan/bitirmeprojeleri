using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Business.Abstract;
using BitirmeProjem.DataAccess.Abstract;
using BitirmeProjem.Entities.Concrete;
using Core.Utilities.Enum;
using BitirmeProjem.Business.ReturnData;

namespace BitirmeProjem.Business.Concrete
{
    public class KategorilerManager : IKategorilerService
    {
        private readonly IKategorilerDal _kategorilerDal;
        public KategorilerManager(IKategorilerDal kategorilerDal)
        {
            _kategorilerDal = kategorilerDal;
        }
        public StatusData<IList<Kategoriler>> GetList(Expression<Func<Kategoriler, bool>> filter)
        {
            var returnData = new StatusData<IList<Kategoriler>>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _kategorilerDal.GetEntities(filter);
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
        public StatusData<Kategoriler> Get(Expression<Func<Kategoriler, bool>> filter)
        {
            var returnData = new StatusData<Kategoriler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _kategorilerDal.Get(filter);

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
        public StatusData<Kategoriler> Add(Kategoriler entity)
        {
            var returnData = new StatusData<Kategoriler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _kategorilerDal.Add(entity);

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
        public StatusData<Kategoriler> Update(Kategoriler entity)
        {
            var returnData = new StatusData<Kategoriler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _kategorilerDal.Update(entity);

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
        public StatusData<Kategoriler> Delete(Expression<Func<Kategoriler, bool>> filter)
        {
            var returnData = new StatusData<Kategoriler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                var entity = _kategorilerDal.Get(filter);
                _kategorilerDal.Delete(entity);

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
    }
}
