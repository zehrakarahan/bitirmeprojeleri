using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Business.ReturnData;

namespace BitirmeProjem.Business.Abstract
{
    public interface IKategorilerService
    {
        StatusData<Kategoriler> Get(Expression<Func<Kategoriler, bool>> filter);
        StatusData<IList<Kategoriler>> GetList(Expression<Func<Kategoriler, bool>> filter);
        StatusData<Kategoriler> Add(Kategoriler entity);
        StatusData<Kategoriler> Update(Kategoriler entity);
        StatusData<Kategoriler> Delete(Expression<Func<Kategoriler, bool>> filter);
    }
}
