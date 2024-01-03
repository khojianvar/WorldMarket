using AutoMapper;
using WorldMarket.Domain.DTOs.Category;
using WorldMarket.Domain.Entities;

namespace WorldMarket.Domain.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings() 
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(x => x.NumberOfProducts, r => r.MapFrom(x => x.Products.Count));
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryForCreateDto, Category>();
            CreateMap<Category, CategoryForCreateDto>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
