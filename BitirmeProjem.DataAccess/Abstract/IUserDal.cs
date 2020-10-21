using Core.DataAccess;
using BitirmeProjem.Entities.Concrete;
using PlakalikSon.Entities.Concrete;

namespace BitirmeProjem.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
