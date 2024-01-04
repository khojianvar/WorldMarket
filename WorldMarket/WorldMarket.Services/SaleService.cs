using AutoMapper;
using WorldMarket.Domain.DTOs.Sale;
using WorldMarket.Domain.Entities;
using WorldMarket.Domain.Interfaces.Services;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;
using WorldMarket.Infrastructure.Persistence;
using WorldMarket.ResourceParameters;
using Microsoft.EntityFrameworkCore.Internal;

namespace WorldMarket.Services
{
    public class SaleService : ISaleService
    {
        private readonly IMapper _mapper;
        private readonly WorldMarketDbContext _context;

        public SaleService(IMapper mapper, WorldMarketDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public PaginatedList<SaleDto> GetSales(SaleResourceParameters saleResourceParameters)
        {
            var query = _context.Sales.AsQueryable();

            if (saleResourceParameters.CustomerId is not null)
            {
                query = query.Where(x => x.CustomerId == saleResourceParameters.CustomerId);
            }

            if (!string.IsNullOrEmpty(saleResourceParameters.OrderBy))
            {
                query = saleResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "id" => query.OrderBy(x => x.Id),
                    "iddesc" => query.OrderByDescending(x => x.Id),
                    "expiredate" => query.OrderBy(x => x.SaleDate),
                    "expiredatedesc" => query.OrderByDescending(x => x.SaleDate),
                    _ => query.OrderBy(x => x.Id),
                };
            }

            var sales = query.ToPaginatedList(saleResourceParameters.PageSize, saleResourceParameters.PageNumber);

            var saleDtos = _mapper.Map<List<SaleDto>>(sales);

            return new PaginatedList<SaleDto>(saleDtos, sales.TotalCount, sales.CurrentPage, sales.PageSize);
        }

        public SaleDto? GetSaleById(int id)
        {
            var sale = _context.Sales.FirstOrDefault(x => x.Id == id);

            var saleDto = _mapper.Map<SaleDto>(sale);

            return saleDto;
        }

        public SaleDto CreateSale(SaleForCreateDto saleToCreate)
        {
            var saleEntity = _mapper.Map<Sale>(saleToCreate);

            _context.Sales.Add(saleEntity);
            _context.SaveChanges();

            var saleDto = _mapper.Map<SaleDto>(saleEntity);

            return saleDto;
        }

        public void UpdateSale(SaleForUpdateDto saleToUpdate)
        {
            var saleEntity = _mapper.Map<Sale>(saleToUpdate);

            _context.Sales.Update(saleEntity);
            _context.SaveChanges();
        }

        public void DeleteSale(int id)
        {
            var sale = _context.Sales.FirstOrDefault(x => x.Id == id);
            if (sale is not null)
            {
                _context.Sales.Remove(sale);
            }
            _context.SaveChanges();
        }
    }
}
