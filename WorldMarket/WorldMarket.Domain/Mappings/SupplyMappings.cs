using AutoMapper;
using WorldMarket.Domain.DTOs.Supply;
using WorldMarket.Domain.Entities;

namespace WorldMarket.Domain.Mappings
{
    public class SupplyMappings : Profile
    {
        public SupplyMappings() 
        {
            CreateMap<SupplyDto, Supply>();
            CreateMap<Supply, SupplyDto>();
            CreateMap<SupplyForCreateDto, Supply>();
            CreateMap<SupplyForUpdateDto, Supply>();
        }
    }
}
