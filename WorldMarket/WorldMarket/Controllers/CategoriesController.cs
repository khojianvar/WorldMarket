﻿using WorldMarket.Domain.DTOs.Category;
using WorldMarket.Domain.DTOs.Product;
using WorldMarket.Domain.Interfaces.Services;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;
using WorldMarket.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WorldMarketApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoriesController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategoriesAsync(
            [FromQuery] CategoryResourceParameters categoryResourceParameters)
        {
            var categories = _categoryService.GetCategories(categoryResourceParameters);

            var metaData = GetPaginationMetaData(categories);

            Response.Headers.Add("X-Pegination", JsonSerializer.Serialize(metaData));

            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<CategoryDto> Get(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            return Ok(category);
        }

        [HttpGet("{id}/products")]
        public ActionResult<ProductDto> GetProductsByCategoryId(
            int id,
            ProductResourceParameters productResourceParameters)
        {
            var products = _productService.GetProducts(productResourceParameters);

            return Ok(products);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CategoryForCreateDto category)
        {
            _categoryService.CreateCategory(category);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CategoryForUpdateDto category)
        {
            if (id != category.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {category.Id}.");
            }

            _categoryService.UpdateCategory(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);

            return NoContent();
        }

        private PaginationMetaData GetPaginationMetaData(PaginatedList<CategoryDto> categories)
        {
            return new PaginationMetaData
            {
                TotalCount = categories.TotalCount,
                PageSize = categories.PageSize,
                CurrentPage = categories.CurrentPage,
                TotalPages = categories.TotalPages,
            };
        }
    }
}
