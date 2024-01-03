using WorldMarket.Domain.DTOs.Supplier;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;

namespace WorldMarket.Domain.Interfaces.Services
{
    public interface ISupplierService
    {
        PaginatedList<SupplierDto> GetSuppliers(SupplierResourceParameters supplierResourceParameters);
        SupplierDto? GetSupplierById(int id);
        SupplierDto CreateSupplier(SupplierForCreateDto supplierToCreate);
        void UpdateSupplier(SupplierForUpdateDto supplierToUpdate);
        void DeleteSupplier(int id);
    }
}
