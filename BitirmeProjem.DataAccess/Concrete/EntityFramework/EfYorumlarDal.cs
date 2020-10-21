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
    public class EfYorumlarDal : EfEntityRepositoryBase<Yorumlar, BitirmeProjemContext>, IYorumlarDal
    {
        protected override List<Yorumlar> GetEntitiesAbstract(Expression<Func<Yorumlar, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.Yorumlars.Include(x=>x.Uyeler).Include(x=>x.Urunler).ToList()
               : context.Yorumlars.Include(x=>x.Uyeler).Include(x=>x.Urunler).Where(filter).ToList();
        }
        protected override Yorumlar GetEntityAbstract(Yorumlar entity, BitirmeProjemContext context)
        {
            throw new NotImplementedException();
        }
        protected override Yorumlar GetEntityAbstract(Expression<Func<Yorumlar, bool>> filter, BitirmeProjemContext context)
        {
            return context.Yorumlars.Include(x=>x.Urunler).Include(x=>x.Uyeler).SingleOrDefault(filter);
        }
        public PageDataTable GetEntitiesForDt(GenericFilter<Yorumlar> filter)
        {
            using (var context = new BitirmeProjemContext())
            {
                var query = context.Yorumlars.Include(x => x.Uyeler).Where(filter.Filter)
                    .Select(x => new { x.ID, x.Puan,x.Onay, Urun = x.Urunler.Adi, Uye = x.Uyeler.Adi + " " + x.Uyeler.Soyadi })
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
