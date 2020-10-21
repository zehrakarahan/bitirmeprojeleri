using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Business.ReturnData;

namespace BitirmeProjem.Business.Abstract
{
    public interface IUyelerService
    {
        StatusData<Uyeler> Get(Expression<Func<Uyeler, bool>> filter);
        StatusData<IList<Uyeler>> GetList(Expression<Func<Uyeler, bool>> filter);
        StatusData<IList<Uyeler>> GetAll();
        StatusData<Uyeler> Add(Uyeler entity);
        StatusData<Uyeler> Update(Uyeler entity);
        StatusData<Uyeler> Delete(Expression<Func<Uyeler, bool>> filter);
        
    }
}
