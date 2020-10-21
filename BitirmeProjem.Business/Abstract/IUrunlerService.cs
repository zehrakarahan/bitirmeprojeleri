using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Business.ReturnData;
using Core.Entities;

namespace BitirmeProjem.Business.Abstract
{
    public interface IUrunlerService
    {
        StatusData<Urunler> Get(Expression<Func<Urunler, bool>> filter);
        StatusData<IList<Urunler>> GetList(Expression<Func<Urunler, bool>> filter);
        StatusData<Urunler> Add(Urunler entity);
        StatusData<Urunler> Update(Urunler entity);
        StatusData<Urunler> Delete(Expression<Func<Urunler, bool>> filter);
        StatusData<PageDataTable> GetEntitiesForDt(GenericFilter<Urunler> filter);

    }
}
