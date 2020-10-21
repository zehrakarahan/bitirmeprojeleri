
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using BitirmeProjem.DataAccess.Concrete.EntityFramework.Contexts;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.DataAccess.Abstract;
using PlakalikSon.Entities.Concrete;

namespace BitirmeProjem.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BitirmeProjemContext>, IUserDal
    {
        protected override List<User> GetEntitiesAbstract(Expression<Func<User, bool>> filter, BitirmeProjemContext context)
        {
            return filter == null
               ? context.Users.ToList()
               : context.Users.Where(filter).ToList();
        }
        protected override User GetEntityAbstract(User entity, BitirmeProjemContext context)
        {
            throw new NotImplementedException();
        }
        protected override User GetEntityAbstract(Expression<Func<User, bool>> filter, BitirmeProjemContext context)
        {
            return context.Users.SingleOrDefault(filter);
        }
    }
}
