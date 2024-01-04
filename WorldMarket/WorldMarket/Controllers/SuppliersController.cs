﻿using WorldMarket.Domain.DTOs.Product;
using WorldMarket.Domain.DTOs.Sale;
using WorldMarket.Domain.DTOs.Supplier;
using WorldMarket.Domain.Entities;
using WorldMarket.Domain.Interfaces.Services;
using WorldMarket.Domain.Pagniation;
using WorldMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WorldMarket.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    [Authorize]
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierDto>> GetSuppliersAsync(
            [FromQuery] SupplierResourceParameters supplierResourceParameters)
        {
            var suppliers = _supplierService.GetSuppliers(supplierResourceParameters);

            var metaData = GetPaginationMetaData(suppliers);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(suppliers);
        }

        [HttpGet("{id}", Name = "GetSupplierById")]
        public ActionResult<SupplierDto> Get(int id)
        {
            var supplier = _supplierService.GetSupplierById(id);

            if (supplier is null)
            {
                return NotFound($"Supplier with id: {id} does not exist.");
            }

            return Ok(supplier);
        }

        [HttpPost]
        public ActionResult Post([FromBody] SupplierForCreateDto supplier)
        {
            _supplierService.CreateSupplier(supplier);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SupplierForUpdateDto supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {supplier.Id}.");
            }

            _supplierService.UpdateSupplier(supplier);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _supplierService.DeleteSupplier(id);

            return NoContent();
        }

        private PaginationMetaData GetPaginationMetaData(PaginatedList<SupplierDto> suppliers)
        {
            return new PaginationMetaData
            {
                TotalCount = suppliers.TotalCount,
                PageSize = suppliers.PageSize,
                CurrentPage = suppliers.CurrentPage,
                TotalPages = suppliers.TotalPages,
            };
        }
    }
}
