using WorldMarket.Domain.DTOs.Supply;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;

namespace WorldMarket.Domain.Interfaces.Services
{
    public interface ISupplyService
    {
        PaginatedList<SupplyDto> GetSupplies(SupplyResourceParameters supplyResourceParameters);
        SupplyDto? GetSupplyById(int id);
        SupplyDto CreateSupply(SupplyForCreateDto supplyToCreate);
        void UpdateSupply(SupplyForUpdateDto supplyToUpdate);
        void DeleteSupply(int id);
    }
}
