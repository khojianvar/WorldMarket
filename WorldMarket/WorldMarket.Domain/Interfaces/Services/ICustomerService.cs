using WorldMarket.Domain.DTOs.Customer;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;

namespace WorldMarket.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        PaginatedList<CustomerDto> GetCustomers(CustomerResourceParameters customerResourceParameters);
        CustomerDto? GetCustomerById(int id);
        CustomerDto CreateCustomer(CustomerForCreateDto customerToCreate);
        void UpdateCustomer(CustomerForUpdateDto customerToUpdate);
        void DeleteCustomer(int id);
    }
}
