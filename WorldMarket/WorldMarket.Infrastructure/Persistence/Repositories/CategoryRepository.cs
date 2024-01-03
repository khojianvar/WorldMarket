using WorldMarket.Domain.Entities;
using WorldMarket.Domain.Interfaces.Repositories;

namespace WorldMarket.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(WorldMarketDbContext context) : base(context)
        {
        }
    }
}
