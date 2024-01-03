using AutoMapper;
using WorldMarket.Domain.DTOs.Category;
using WorldMarket.Domain.Entities;

namespace WorldMarket.Domain.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings() 
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryForCreateDto, Category>();
            CreateMap<Category, CategoryForCreateDto>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
