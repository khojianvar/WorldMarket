using AutoMapper;
using WorldMarket.Domain.DTOs.SaleItem;
using WorldMarket.Domain.Entities;

namespace WorldMarket.Domain.Mappings
{
    public class SaleItemMappings : Profile
    {
        public SaleItemMappings() 
        {
            CreateMap<SaleItemDto, SaleItem>();
            CreateMap<SaleItem, SaleItemDto>();
            CreateMap<SaleItemForCreateDto, SaleItem>();
            CreateMap<SaleItemForUpdateDto, SaleItem>();
        }
    }
}
