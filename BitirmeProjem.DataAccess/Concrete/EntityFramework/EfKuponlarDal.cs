using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using BitirmeProjem.DataAccess.Concrete.EntityFramework.Contexts;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.DataAccess.Abstract;
using Core.Entities;
using Core.Utilities.ExtensionMethods;

namespace BitirmeProjem.DataAccess.Concrete.EntityFramework
{
    public class EfKuponlarDal : EfEntityRepositoryBase<Kuponlar, BitirmeProjemContext>, IKuponlarDal
    {
        protected override List<Kuponlar> GetEntitiesAbstract(Expression<Func<Kuponlar, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.Kuponlars.ToList()
               : context.Kuponlars.Where(filter).ToList();
        }
        protected override Kuponlar GetEntityAbstract(Kuponlar entity, BitirmeProjemContext context)
        {
            throw new NotImplementedException();
        }
        protected override Kuponlar GetEntityAbstract(Expression<Func<Kuponlar, bool>> filter, BitirmeProjemContext context)
        {
            return context.Kuponlars.SingleOrDefault(filter);
        }
        public PageDataTable GetEntitiesForDt(GenericFilter<Kuponlar> filter)
        {
            using (var context = new BitirmeProjemContext())
            {
                var query = context.Kuponlars.Where(filter.Filter)
                    .AsQueryable();
                var result = new PageDataTable();
                if (!string.IsNullOrEmpty(filter.Sort) && filter.Sort != "0")
                    query = query.OrderByField(filter.Sort, filter.Order.ToLower() == "asc");

                result.total = query.Count();

                if (filter.Limit != null)
                {
                    if (filter.Offset != null)
                        result.rows = query.Skip(filter.Offset.Value).Take(filter.Limit.Value).ToList();
                }
                else
                {
                    result.rows = query.ToList();
                }
                return result;
            }
        }

    }
}
