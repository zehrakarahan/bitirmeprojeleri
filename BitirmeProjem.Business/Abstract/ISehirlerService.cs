using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Business.ReturnData;

namespace BitirmeProjem.Business.Abstract
{
    public interface ISehirlerService
    {
        StatusData<Sehirler> Get(Expression<Func<Sehirler, bool>> filter);
        StatusData<IList<Sehirler>> GetList(Expression<Func<Sehirler, bool>> filter);
        StatusData<IList<Sehirler>> GetAll();
        StatusData<Sehirler> Add(Sehirler entity);
        StatusData<Sehirler> Update(Sehirler entity);
        StatusData<Sehirler> Delete(Expression<Func<Sehirler, bool>> filter);
    }
}
//uı yapısından cekiyo 