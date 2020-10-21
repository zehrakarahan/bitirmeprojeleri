using Core.DataAccess;
using BitirmeProjem.Entities.Concrete;
using Core.Entities;

namespace BitirmeProjem.DataAccess.Abstract
{
    public interface IUrunlerDal : IEntityRepository<Urunler>
    {
        PageDataTable GetEntitiesForDt(GenericFilter<Urunler> filter);
    }
}
