using WorldMarket.Domain.DTOs.SupplyItem;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;

namespace WorldMarket.Domain.Interfaces.Services
{
    public interface ISupplyItemService
    {
        PaginatedList<SupplyItemDto> GetSupplyItems(SupplyItemResourceParameters supplyItemResourceParameters);
        SupplyItemDto? GetSupplyItemById(int id);
        SupplyItemDto CreateSupplyItem(SupplyItemForCreateDto supplyItemToCreate);
        void UpdateSupplyItem(SupplyItemForUpdateDto supplyItemToUpdate);
        void DeleteSupplyItem(int id);
    }
}
