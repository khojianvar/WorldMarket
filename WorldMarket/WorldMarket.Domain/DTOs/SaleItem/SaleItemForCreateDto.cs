namespace WorldMarket.Domain.DTOs.SaleItem
{
    public record SaleItemForCreateDto(
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SaleId);
}
