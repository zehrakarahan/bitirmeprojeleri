using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Business.ReturnData;
namespace BitirmeProjem.Business.Abstract
{
    public interface IFavorilerService
    {
        StatusData<Favoriler> Get(Expression<Func<Favoriler, bool>> filter);
        StatusData<IList<Favoriler>> GetList(Expression<Func<Favoriler, bool>> filter);
        StatusData<IList<Favoriler>> GetAll();
        StatusData<Favoriler> Add(Favoriler entity);
        StatusData<Favoriler> Update(Favoriler entity);
        StatusData<Favoriler> Delete(Expression<Func<Favoriler, bool>> filter);
    }
}
