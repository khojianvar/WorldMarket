using WorldMarket.Domain.Entities;
using WorldMarket.Domain.Interfaces.Repositories;

namespace WorldMarket.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(WorldMarketDbContext context)
            : base(context)
        {
        }
    }
}
