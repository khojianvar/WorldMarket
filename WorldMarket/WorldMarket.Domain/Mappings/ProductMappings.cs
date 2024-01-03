using AutoMapper;
using WorldMarket.Domain.DTOs.Product;
using WorldMarket.Domain.Entities;

namespace WorldMarket.Domain.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings() 
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductForCreateDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();
        }
    }
}
