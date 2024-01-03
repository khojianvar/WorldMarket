using AutoMapper;
using WorldMarket.Domain.DTOs.Customer;
using WorldMarket.Domain.Entities;

namespace WorldMarket.Domain.Mappings
{
    internal class CustomerMappings : Profile
    {
        public CustomerMappings() 
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CustomerForCreateDto, Customer>();
            CreateMap<CustomerForUpdateDto, Customer>();
        }
    }
}
