namespace WorldMarket.Domain.DTOs.SupplyItem
{
    public record SupplyItemForCreateDto(
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SupplyId);
}
