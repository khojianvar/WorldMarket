﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WorldMarket.Domain.DTOs.Sale;
using WorldMarket.Domain.DTOs.SaleItem;
using WorldMarket.Domain.Interfaces.Services;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;

namespace WorldMarket.Controllers
{
    [Route("api/sales")]
    [ApiController]
    [Authorize]
    public class SalesController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly ISaleItemService _saleItemService;
        public SalesController(ISaleService saleService, ISaleItemService saleItemService)
        {
            _saleService = saleService;
            _saleItemService = saleItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SaleDto>> GetSalesAsync(
            [FromQuery] SaleResourceParameters saleResourceParameters)
        {
            var sales = _saleService.GetSales(saleResourceParameters);

            var metaData = GetPaginationMetaData(sales);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(sales);
        }

        [HttpGet("{id}", Name = "GetSaleById")]
        public ActionResult<SaleDto> Get(int id)
        {
            var sale = _saleService.GetSaleById(id);

            if (sale is null)
            {
                return NotFound($"Sale with id: {id} does not exist.");
            }

            return Ok(sale);
        }

        [HttpGet("{id}/saleItems")]
        public ActionResult<SaleItemDto> GetSaleItemsBySaleId(int id, SaleItemResourceParameters saleItemResourceParameters)
        {
            var saleItems = _saleItemService.GetSaleItems(saleItemResourceParameters);

            var filteredSaleItems = saleItems.Where(x => x.SaleId == id).ToList();

            return Ok(filteredSaleItems);
        }

        [HttpPost]
        public ActionResult Post([FromBody] SaleForCreateDto sale)
        {
            _saleService.CreateSale(sale);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SaleForUpdateDto sale)
        {
            if (id != sale.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {sale.Id}.");
            }

            _saleService.UpdateSale(sale);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _saleService.DeleteSale(id);

            return NoContent();
        }

        private PaginationMetaData GetPaginationMetaData(PaginatedList<SaleDto> sales)
        {
            return new PaginationMetaData
            {
                TotalCount = sales.TotalCount,
                PageSize = sales.PageSize,
                CurrentPage = sales.CurrentPage,
                TotalPages = sales.TotalPages,
            };
        }
    }

    class PaginationMetaData
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
