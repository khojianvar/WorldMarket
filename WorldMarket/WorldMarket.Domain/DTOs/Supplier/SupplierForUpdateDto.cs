﻿namespace WorldMarket.Domain.DTOs.Supplier
{
    public record SupplierForUpdateDto(
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Company);
}
