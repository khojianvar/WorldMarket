namespace WorldMarket.Domain.DTOs.Product
{
    public record class ProductDto(
        int Id,
        string Name,
        string Description,
        decimal Price,
        DateTime ExpireDate,
        int CategoryId,
        ICollection<SaleItemDto> SaleItems,
        ICollection<SupplyItemDto> SupplyItems);
}
