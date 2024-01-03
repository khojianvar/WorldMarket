using WorldMarket.Domain.DTOs.Sale;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;

namespace WorldMarket.Domain.Interfaces.Services
{
    public interface ISaleService
    {
        PaginatedList<SaleDto> GetSales(SaleResourceParameters saleResourceParameters);
        SaleDto? GetSaleById(int id);
        SaleDto CreateSale(SaleForCreateDto saleToCreate);
        void UpdateSale(SaleForUpdateDto saleToUpdate);
        void DeleteSale(int id);
    }
}
