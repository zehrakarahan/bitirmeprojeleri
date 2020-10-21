using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Business.ReturnData;
using BitirmeProjem.Entities.Concrete;
using Core.Entities;

namespace BitirmeProjem.Business.Abstract
{
    public interface IKuponlarService
    {
        StatusData<Kuponlar> Get(Expression<Func<Kuponlar, bool>> filter);
        StatusData<IList<Kuponlar>> GetList(Expression<Func<Kuponlar, bool>> filter);
        StatusData<Kuponlar> Add(Kuponlar entity);
        StatusData<Kuponlar> Update(Kuponlar entity);
        StatusData<Kuponlar> Delete(Expression<Func<Kuponlar, bool>> filter);
        StatusData<PageDataTable> GetEntitiesForDt(GenericFilter<Kuponlar> filter);

    }
}
