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
    public class EfFavoriler : EfEntityRepositoryBase<Favoriler, BitirmeProjemContext>, IFavorilerDal
    {
        protected override List<Favoriler> GetEntitiesAbstract(Expression<Func<Favoriler, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.Favorilers.ToList()
               : context.Favorilers.Where(filter).ToList();
        }

        protected override Favoriler GetEntityAbstract(Expression<Func<Favoriler, bool>> filter, BitirmeProjemContext context)
        {
            return context.Favorilers.SingleOrDefault(filter);
        }

        protected override Favoriler GetEntityAbstract(Favoriler entity, BitirmeProjemContext context)
        {
            return context.Favorilers.SingleOrDefault();
        }
    }
}
