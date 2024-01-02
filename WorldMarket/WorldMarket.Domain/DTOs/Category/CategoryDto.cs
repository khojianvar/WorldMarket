namespace WorldMarket.Domain.DTOs.Category
{
    public record class CategoryDto(
        int Id,
        string Name,
        ICollection<ProductDto> Products);
}
