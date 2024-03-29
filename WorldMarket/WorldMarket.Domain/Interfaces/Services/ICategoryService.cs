﻿using WorldMarket.Domain.DTOs.Category;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;

namespace WorldMarket.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        PaginatedList<CategoryDto> GetCategories(CategoryResourceParameters categoryResourceParameters);
        CategoryDto? GetCategoryById(int id);
        CategoryDto CreateCategory(CategoryForCreateDto categoryToCreate);
        void UpdateCategory(CategoryForUpdateDto categoryToUpdate);
        void DeleteCategory(int id);
    }
}
