using WorldMarket.Domain.DTOs.Sale;

namespace WorldMarket.Domain.DTOs.Customer
{
    public record CustomerDto(
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        ICollection<SaleDto> Sales);
}
