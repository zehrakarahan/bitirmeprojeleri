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
    public class YorumlarManager : IYorumlarService
    {
        private readonly IYorumlarDal _yorumlarDal;
        public YorumlarManager(IYorumlarDal yorumlarDal)
        {
            _yorumlarDal = yorumlarDal;
        }
        public StatusData<IList<Yorumlar>> GetList(Expression<Func<Yorumlar, bool>> filter)
        {
            var returnData = new StatusData<IList<Yorumlar>>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _yorumlarDal.GetEntities(filter);
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
        public StatusData<Yorumlar> Get(Expression<Func<Yorumlar, bool>> filter)
        {
            var returnData = new StatusData<Yorumlar>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _yorumlarDal.Get(filter);

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
        public StatusData<Yorumlar> Add(Yorumlar entity)
        {
            var returnData = new StatusData<Yorumlar>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _yorumlarDal.Add(entity);

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
        public StatusData<Yorumlar> Update(Yorumlar entity)
        {
            var returnData = new StatusData<Yorumlar>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _yorumlarDal.Update(entity);

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
        public StatusData<Yorumlar> Delete(Expression<Func<Yorumlar, bool>> filter)
        {
            var returnData = new StatusData<Yorumlar>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                var entity = _yorumlarDal.Get(filter);
                _yorumlarDal.Delete(entity);

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
        public StatusData<PageDataTable> GetEntitiesForDt(GenericFilter<Yorumlar> filter)
        {
            var returnData = new StatusData<PageDataTable>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _yorumlarDal.GetEntitiesForDt(filter);
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
