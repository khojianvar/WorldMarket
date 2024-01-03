using AutoMapper;
using WorldMarket.Domain.DTOs.SupplyItem;
using WorldMarket.Domain.Entities;

namespace WorldMarket.Domain.Mappings
{
    public class SupplyItemMappings : Profile
    {
        public SupplyItemMappings() 
        {
            CreateMap<SupplyItemDto, SupplyItem>();
            CreateMap<SupplyItem, SupplyItemDto>();
            CreateMap<SupplyItemForCreateDto, SupplyItem>();
            CreateMap<SupplyItemForUpdateDto, SupplyItem>();
        }
    }
}
