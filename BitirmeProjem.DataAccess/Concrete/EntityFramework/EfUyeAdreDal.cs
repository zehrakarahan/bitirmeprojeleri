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
    public class EfUyeAdreDal : EfEntityRepositoryBase<UyeAdres, BitirmeProjemContext>, IUyeAdreDal
    {
        protected override List<UyeAdres> GetEntitiesAbstract(Expression<Func<UyeAdres, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.UyeAdres.ToList()
               : context.UyeAdres.Where(filter).ToList();
        }
        protected override UyeAdres GetEntityAbstract(UyeAdres entity, BitirmeProjemContext context)
        {
            throw new NotImplementedException();
        }
        protected override UyeAdres GetEntityAbstract(Expression<Func<UyeAdres, bool>> filter, BitirmeProjemContext context)
        {
            return context.UyeAdres.SingleOrDefault(filter);
        }
    }
}
