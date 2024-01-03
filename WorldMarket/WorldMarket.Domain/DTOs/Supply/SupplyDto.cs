using WorldMarket.Domain.DTOs.SupplyItem;

namespace WorldMarket.Domain.DTOs.Supply
{
    public record SupplyDto(
        int Id,
        DateTime SupplyDate,
        int SupplierId,
        ICollection<SupplyItemDto> SupplyItems);
}
