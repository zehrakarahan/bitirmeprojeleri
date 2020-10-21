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
    public class UyeAdresManager : IUyeAdreService
    {
        private readonly IUyeAdreDal _UyeAdresDal;
        public UyeAdresManager(IUyeAdreDal UyeAdresDal)
        {
            _UyeAdresDal = UyeAdresDal;
        }
        public StatusData<IList<UyeAdres>> GetList(Expression<Func<UyeAdres, bool>> filter)
        {
            var returnData = new StatusData<IList<UyeAdres>>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _UyeAdresDal.GetEntities(filter);
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
        public StatusData<UyeAdres> Get(Expression<Func<UyeAdres, bool>> filter)
        {
            var returnData = new StatusData<UyeAdres>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _UyeAdresDal.Get(filter);

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
        public StatusData<UyeAdres> Add(UyeAdres entity)
        {
            var returnData = new StatusData<UyeAdres>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _UyeAdresDal.Add(entity);

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
        public StatusData<UyeAdres> Update(UyeAdres entity)
        {
            var returnData = new StatusData<UyeAdres>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _UyeAdresDal.Update(entity);

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
        public StatusData<UyeAdres> Delete(Expression<Func<UyeAdres, bool>> filter)
        {
            var returnData = new StatusData<UyeAdres>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                var entity = _UyeAdresDal.Get(filter);
                //entity.Status = (byte)Enums.Statuses.Delete;
                _UyeAdresDal.Update(entity);

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
        public StatusData<IList<UyeAdres>> GetAll()
        {
            var returnData = new StatusData<IList<UyeAdres>>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _UyeAdresDal.GetEntities();
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
    }
}
