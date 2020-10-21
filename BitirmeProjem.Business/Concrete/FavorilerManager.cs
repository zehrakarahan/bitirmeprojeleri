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
    public class FavorilerManager: IFavorilerService
    {
        private readonly IFavorilerDal _favorilerDal;
        public FavorilerManager(IFavorilerDal favorilerDal)
        {
            _favorilerDal = favorilerDal;
        }
        public StatusData<IList<Favoriler>> GetList(Expression<Func<Favoriler, bool>> filter)
        {
            var returnData = new StatusData<IList<Favoriler>>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _favorilerDal.GetEntities(filter);
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
        public StatusData<Favoriler> Get(Expression<Func<Favoriler, bool>> filter)
        {
            var returnData = new StatusData<Favoriler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _favorilerDal.Get(filter);

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
        public StatusData<Favoriler> Add(Favoriler entity)
        {
            var returnData = new StatusData<Favoriler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _favorilerDal.Add(entity);

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
        public StatusData<Favoriler> Update(Favoriler entity)
        {
            var returnData = new StatusData<Favoriler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _favorilerDal.Update(entity);

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
        public StatusData<Favoriler> Delete(Expression<Func<Favoriler, bool>> filter)
        {
            var returnData = new StatusData<Favoriler>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                var entity = _favorilerDal.Get(filter);
                _favorilerDal.Update(entity);

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
        public StatusData<IList<Favoriler>> GetAll()
        {
            var returnData = new StatusData<IList<Favoriler>>();
            try
            {
                returnData.Status.MethodBase = System.Reflection.MethodBase.GetCurrentMethod();
                returnData.Entity = _favorilerDal.GetEntities();
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
