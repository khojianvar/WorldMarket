﻿namespace WorldMarket.Domain.DTOs.Sale
{
    public record SaleForCreateDto(
        DateTime SaleDate,
        int CustomerId);
}
