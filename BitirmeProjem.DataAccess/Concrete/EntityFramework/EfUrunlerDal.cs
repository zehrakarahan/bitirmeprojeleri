using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class EfUrunlerDal : EfEntityRepositoryBase<Urunler, BitirmeProjemContext>, IUrunlerDal
    {
        protected override List<Urunler> GetEntitiesAbstract(Expression<Func<Urunler, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.Urunlers.Include(x=>x.Kategoriler).ToList()
               : context.Urunlers.Include(x => x.Kategoriler).Where(filter).ToList();
        }
        protected override Urunler GetEntityAbstract(Urunler entity, BitirmeProjemContext context)
        {
            throw new NotImplementedException();
        }
        protected override Urunler GetEntityAbstract(Expression<Func<Urunler, bool>> filter, BitirmeProjemContext context)
        {
            return context.Urunlers.SingleOrDefault(filter);
        }

        public PageDataTable GetEntitiesForDt(GenericFilter<Urunler> filter)
        {
            using (var context = new BitirmeProjemContext())
            {
                var query = context.Urunlers.Include(x=>x.Kategoriler).Where(filter.Filter)
                    .Select(x=>new {x.ID,x.Adi,x.Stok,x.Fiyat,Kategori=x.Kategoriler.Adi})
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
