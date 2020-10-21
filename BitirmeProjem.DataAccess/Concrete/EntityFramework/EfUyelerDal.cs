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
    public class EfUyelerDal : EfEntityRepositoryBase<Uyeler, BitirmeProjemContext>, IUyelerDal
    {
        protected override List<Uyeler> GetEntitiesAbstract(Expression<Func<Uyeler, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.Uyelers.ToList()
               : context.Uyelers.Where(filter).ToList();
        }
        protected override Uyeler GetEntityAbstract(Uyeler entity, BitirmeProjemContext context)
        {
            throw new NotImplementedException();
        }
        protected override Uyeler GetEntityAbstract(Expression<Func<Uyeler, bool>> filter, BitirmeProjemContext context)
        {
            return context.Uyelers.SingleOrDefault(filter);
        }
    }
}
