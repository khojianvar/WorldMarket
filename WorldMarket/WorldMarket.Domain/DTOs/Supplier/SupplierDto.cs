namespace WorldMarket.Domain.DTOs.Supplier
{
    public record SupplierDto(
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Company,
        ICollection<SupplyDto> Supplies);
}
