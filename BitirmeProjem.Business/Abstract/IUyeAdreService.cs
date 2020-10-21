using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Business.ReturnData;

namespace BitirmeProjem.Business.Abstract
{
    public interface IUyeAdreService
    {
        StatusData<UyeAdres> Get(Expression<Func<UyeAdres, bool>> filter);
        StatusData<IList<UyeAdres>> GetList(Expression<Func<UyeAdres, bool>> filter);
        StatusData<IList<UyeAdres>> GetAll();
        StatusData<UyeAdres> Add(UyeAdres entity);
        StatusData<UyeAdres> Update(UyeAdres entity);
        StatusData<UyeAdres> Delete(Expression<Func<UyeAdres, bool>> filter);
    }
}
