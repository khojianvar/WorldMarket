using WorldMarket.Domain.DTOs.Category;
using WorldMarket.Domain.DTOs.SaleItem;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMarket.Domain.Interfaces.Services
{
    public interface ISaleItemService
    {
        PaginatedList<SaleItemDto> GetSaleItems(SaleItemResourceParameters saleItemResourceParameters);
        SaleItemDto? GetSaleItemById(int id);
        SaleItemDto CreateSaleItem(SaleItemForCreateDto saleItemToCreate);
        void UpdateSaleItem(SaleItemForUpdateDto saleItemToUpdate);
        void DeleteSaleItem(int id);
    }
}
