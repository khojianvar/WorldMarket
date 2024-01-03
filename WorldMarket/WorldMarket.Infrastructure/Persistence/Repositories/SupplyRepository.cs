using WorldMarket.Domain.Entities;
using WorldMarket.Domain.Interfaces.Repositories;

namespace WorldMarket.Infrastructure.Persistence.Repositories
{
    public class SupplyRepository : RepositoryBase<Supply>, ISupplyRepository
    {
        public SupplyRepository(WorldMarketDbContext context)
            : base(context)
        {
        }
    }
}
