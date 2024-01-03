using AutoMapper;
using WorldMarket.Domain.DTOs.Supplier;
using WorldMarket.Domain.Entities;

namespace WorldMarket.Domain.Mappings
{
    public class SupplierMappings : Profile
    {
        public SupplierMappings() 
        {
            CreateMap<SupplierDto, Supplier>();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierForCreateDto, Supplier>();
            CreateMap<SupplierForUpdateDto, Supplier>();
        }
    }
}
