using WorldMarket.Domain.DTOs.Product;
using WorldMarket.Domain.Pagniation;
using WorldMarket.ResourceParameters;

namespace WorldMarket.Domain.Interfaces.Services
{
    public interface IProductService
    {
        PaginatedList<ProductDto> GetProducts(ProductResourceParameters productResourceParameters);
        ProductDto? GetProductById(int id);
        ProductDto CreateProduct(ProductForCreateDto productToCreate);
        void UpdateProduct(ProductForUpdateDto productToUpdate);
        void DeleteProduct(int id);
    }
}
