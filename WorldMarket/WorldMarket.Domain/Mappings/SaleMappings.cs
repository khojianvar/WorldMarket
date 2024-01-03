using AutoMapper;
using WorldMarket.Domain.DTOs.Sale;
using WorldMarket.Domain.Entities;

namespace WorldMarket.Domain.Mappings
{
    public class SaleMappings : Profile
    {
        public SaleMappings() 
        {
            CreateMap<SaleDto, Sale>();
            CreateMap<Sale, SaleDto>();
            CreateMap<SaleForCreateDto, Sale>();
            CreateMap<SaleForUpdateDto, Sale>();
        }
    }
}
