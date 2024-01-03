using WorldMarket.Domain.DTOs.Category;
using WorldMarket.Domain.DTOs.Supply;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
