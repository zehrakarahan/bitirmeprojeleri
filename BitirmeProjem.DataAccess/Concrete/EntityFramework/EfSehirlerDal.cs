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
    public class EfSehirlerDal : EfEntityRepositoryBase<Sehirler, BitirmeProjemContext>, ISehirlerDal
    {
        protected override List<Sehirler> GetEntitiesAbstract(Expression<Func<Sehirler, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.Sehirlers.ToList()
               : context.Sehirlers.Where(filter).ToList();
        }
        protected override Sehirler GetEntityAbstract(Sehirler entity, BitirmeProjemContext context)
        {
            throw new NotImplementedException();
        }
        protected override Sehirler GetEntityAbstract(Expression<Func<Sehirler, bool>> filter, BitirmeProjemContext context)
        {
            return context.Sehirlers.SingleOrDefault(filter);
        }
    }
}
