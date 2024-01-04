using AutoMapper;
using WorldMarket.Domain.DTOs.Customer;
using WorldMarket.Domain.Entities;
using WorldMarket.Domain.Interfaces.Services;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;
using WorldMarket.Infrastructure.Persistence;

namespace WorldMarket.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly WorldMarketDbContext _context;

        public CustomerService(IMapper mapper, WorldMarketDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public PaginatedList<CustomerDto> GetCustomers(CustomerResourceParameters customerResourceParameters)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(customerResourceParameters.SearchString))
            {
                query = query.Where(x => x.FirstName.Contains(customerResourceParameters.SearchString)
                || x.LastName.Contains(customerResourceParameters.SearchString)
                || x.PhoneNumber.Contains(customerResourceParameters.SearchString));
            }

            if (!string.IsNullOrEmpty(customerResourceParameters.OrderBy))
            {
                query = customerResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "firstname" => query.OrderBy(x => x.FirstName),
                    "firstnamedesc" => query.OrderByDescending(x => x.FirstName),
                    "lastname" => query.OrderBy(x => x.LastName),
                    "lastnamedesc" => query.OrderByDescending(x => x.LastName),
                    "phonenumber" => query.OrderBy(x => x.PhoneNumber),
                    "phonenumberdesc" => query.OrderByDescending(x => x.PhoneNumber),
                    _ => query.OrderBy(x => x.FirstName),
                };
            }

            var customers = query.ToPaginatedList(customerResourceParameters.PageSize, customerResourceParameters.PageNumber);

            var customerDtos = _mapper.Map<List<CustomerDto>>(customers);

            return new PaginatedList<CustomerDto>(customerDtos, customers.TotalCount, customers.CurrentPage, customers.PageSize);
        }

        public CustomerDto? GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto;
        }

        public CustomerDto CreateCustomer(CustomerForCreateDto customerToCreate)
        {
            var customerEntity = _mapper.Map<Customer>(customerToCreate);

            _context.Customers.Add(customerEntity);
            _context.SaveChanges();

            var customerDto = _mapper.Map<CustomerDto>(customerEntity);

            return customerDto;
        }

        public void UpdateCustomer(CustomerForUpdateDto customerToUpdate)
        {
            var customerEntity = _mapper.Map<Customer>(customerToUpdate);

            _context.Customers.Update(customerEntity);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer is not null)
            {
                _context.Customers.Remove(customer);
            }
            _context.SaveChanges();
        }
    }
}
