﻿using WorldMarket.Domain.DTOs.Product;
using WorldMarket.Domain.DTOs.Supply;
using WorldMarket.Domain.DTOs.SupplyItem;
using WorldMarket.Domain.Entities;
using WorldMarket.Domain.Interfaces.Services;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;
using WorldMarket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WorldMarket.Controllers
{
    [Route("api/supplyItems")]
    [ApiController]
    [Authorize]
    public class SupplyItemsController : Controller
    {
        private readonly ISupplyItemService _supplyItemService;
        public SupplyItemsController(ISupplyItemService supplyItemService)
        {
            _supplyItemService = supplyItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplyItemDto>> Get(
            [FromQuery] SupplyItemResourceParameters supplyItemResourceParameters)
        {
            var supplyItems = _supplyItemService.GetSupplyItems(supplyItemResourceParameters);

            var metaData = GetPaginationMetaData(supplyItems);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));


            return Ok(supplyItems);
        }

        [HttpGet("{id}", Name = "GetSupplyItemById")]
        public ActionResult<SupplyItemDto> Get(int id)
        {
            var supplyItem = _supplyItemService.GetSupplyItemById(id);

            if (supplyItem is null)
            {
                return NotFound($"SupplyItem with id: {id} does not exist.");
            }

            return Ok(supplyItem);
        }

        [HttpPost]
        public ActionResult Post([FromBody] SupplyItemForCreateDto supplyItem)
        {
            _supplyItemService.CreateSupplyItem(supplyItem);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SupplyItemForUpdateDto supplyItem)
        {
            if (id != supplyItem.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {supplyItem.Id}.");
            }

            _supplyItemService.UpdateSupplyItem(supplyItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _supplyItemService.DeleteSupplyItem(id);

            return NoContent();
        }

        private PaginationMetaData GetPaginationMetaData(PaginatedList<SupplyItemDto> supplyItems)
        {
            return new PaginationMetaData
            {
                TotalCount = supplyItems.TotalCount,
                PageSize = supplyItems.PageSize,
                CurrentPage = supplyItems.CurrentPage,
                TotalPages = supplyItems.TotalPages,
            };
        }
    }
}
