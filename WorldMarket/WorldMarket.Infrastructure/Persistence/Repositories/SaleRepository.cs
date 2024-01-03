using WorldMarket.Domain.Entities;
using WorldMarket.Domain.Interfaces.Repositories;

namespace WorldMarket.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        public SaleRepository(WorldMarketDbContext context)
            : base(context) 
        {
        }
    }
}
