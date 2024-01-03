using WorldMarket.Domain.Entities;
using WorldMarket.Domain.Interfaces.Repositories;

namespace WorldMarket.Infrastructure.Persistence.Repositories
{
    public class SupplyItemRepository : RepositoryBase<SupplyItem>, ISupplyItemRepository
    {
        public SupplyItemRepository(WorldMarketDbContext context)
            : base(context)
        {
        }
    }
}
