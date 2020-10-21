using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using BitirmeProjem.DataAccess.Concrete.EntityFramework.Contexts;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.DataAccess.Abstract;

namespace BitirmeProjem.DataAccess.Concrete.EntityFramework
{
    public class EfKategorilerDal : EfEntityRepositoryBase<Kategoriler, BitirmeProjemContext>, IKategorilerDal
    {
        protected override List<Kategoriler> GetEntitiesAbstract(Expression<Func<Kategoriler, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.Kategorilers.ToList()
               : context.Kategorilers.Where(filter).ToList();
        }
        protected override Kategoriler GetEntityAbstract(Kategoriler entity, BitirmeProjemContext context)
        {
            throw new NotImplementedException();
        }
        protected override Kategoriler GetEntityAbstract(Expression<Func<Kategoriler, bool>> filter, BitirmeProjemContext context)
        {
            return context.Kategorilers.SingleOrDefault(filter);
        }
    }
}
