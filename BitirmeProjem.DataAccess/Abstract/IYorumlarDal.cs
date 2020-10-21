using Core.DataAccess;
using BitirmeProjem.Entities.Concrete;
using Core.Entities;

namespace BitirmeProjem.DataAccess.Abstract
{
    public interface IYorumlarDal : IEntityRepository<Yorumlar>
    {
        PageDataTable GetEntitiesForDt(GenericFilter<Yorumlar> filter);
    }
}
