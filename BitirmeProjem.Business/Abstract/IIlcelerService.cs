using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Business.ReturnData;

namespace BitirmeProjem.Business.Abstract
{
    public interface IIlcelerService
    {
        StatusData<Ilceler> Get(Expression<Func<Ilceler, bool>> filter);
        StatusData<IList<Ilceler>> GetList(Expression<Func<Ilceler, bool>> filter);
        StatusData<Ilceler> Add(Ilceler entity);
        StatusData<Ilceler> Update(Ilceler entity);
        StatusData<Ilceler> Delete(Expression<Func<Ilceler, bool>> filter);
    }
}
