using WorldMarket.Domain.Common;

namespace WorldMarket.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
