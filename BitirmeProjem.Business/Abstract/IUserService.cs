using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Business.ReturnData;
using PlakalikSon.Entities.Concrete;

namespace BitirmeProjem.Business.Abstract
{
    public interface IUserService
    {
        StatusData<User> Get(Expression<Func<User, bool>> filter);
        StatusData<IList<User>> GetList(Expression<Func<User, bool>> filter);
        StatusData<User> Add(User entity);
        StatusData<User> Update(User entity);
        StatusData<User> Delete(Expression<Func<User, bool>> filter);
    }
}
