using WorldMarket.Domain.DTOs.SaleItem;

namespace WorldMarket.Domain.DTOs.Sale
{
    public record SaleDto(
        int Id,
        DateTime SaleDate,
        int CustomerId,
        ICollection<SaleItemDto> SaleItems);
}
