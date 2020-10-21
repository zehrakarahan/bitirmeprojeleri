using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using BitirmeProjem.DataAccess.Concrete.EntityFramework.Contexts;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.DataAccess.Abstract;

namespace BitirmeProjem.DataAccess.Concrete.EntityFramework
{
    public class EfIlcelerDal : EfEntityRepositoryBase<Ilceler, BitirmeProjemContext>, IIlcelerDal
    {
        protected override List<Ilceler> GetEntitiesAbstract(Expression<Func<Ilceler, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.Ilcelers.ToList()
               : context.Ilcelers.Where(filter).ToList();
        }
        protected override Ilceler GetEntityAbstract(Ilceler entity, BitirmeProjemContext context)
        {
            throw new NotImplementedException();
        }
        protected override Ilceler GetEntityAbstract(Expression<Func<Ilceler, bool>> filter, BitirmeProjemContext context)
        {
            return context.Ilcelers.SingleOrDefault(filter);
        }
    }
}
