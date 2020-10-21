using Core.DataAccess;
using BitirmeProjem.Entities.Concrete;
using Core.Entities;

namespace BitirmeProjem.DataAccess.Abstract
{
    public interface IKuponlarDal : IEntityRepository<Kuponlar>
    {
        PageDataTable GetEntitiesForDt(GenericFilter<Kuponlar> filter);

    }
}
