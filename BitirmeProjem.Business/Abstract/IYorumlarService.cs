using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Business.ReturnData;
using Core.Entities;

namespace BitirmeProjem.Business.Abstract
{
    public interface IYorumlarService
    {
        StatusData<Yorumlar> Get(Expression<Func<Yorumlar, bool>> filter);
        StatusData<IList<Yorumlar>> GetList(Expression<Func<Yorumlar, bool>> filter);
        StatusData<Yorumlar> Add(Yorumlar entity);
        StatusData<Yorumlar> Update(Yorumlar entity);
        StatusData<Yorumlar> Delete(Expression<Func<Yorumlar, bool>> filter);
        StatusData<PageDataTable> GetEntitiesForDt(GenericFilter<Yorumlar> filter);
        
    }
}
