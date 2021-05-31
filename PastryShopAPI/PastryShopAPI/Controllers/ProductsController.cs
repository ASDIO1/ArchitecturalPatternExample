using PastryShopAPI.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PastryShopAPI.Services;

namespace PastryShopAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // api/teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductsAsync(string orderBy = "Id")
        {
            try
            {
                var products = await _productsService.GetProductsAsync(orderBy);
                return Ok(products);
            }
            catch (InvalidOperationItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        // api/teams/2
        [HttpGet("{productId:long}")]
        public async Task<ActionResult<ProductModel>> GetProductAsync(long productId)// public async Task<ActionResult<CategoryWithProductModel>> GetProductAsync(long teamId)
        {
            try
            {
                var product = await _productsService.GetProductAsync(productId);
                return Ok(product);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        // api/teams
        [HttpPost]
        public async Task<ActionResult<ProductModel>> CreateProductAsync([FromBody] ProductModel newProduct)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var product = await _productsService.CreateProductAsync(newProduct);
                return Created($"/api/products/{product.Id}", product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpDelete("{productId:long}")]
        public async Task<ActionResult<bool>> DeleteProductAsync(long productId)
        {
            try
            {
                var result = await _productsService.DeleteProductAsync(productId);
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpPut("{productId:long}")]
        public async Task<ActionResult<ProductModel>> UpdateProductAsync(long productId, [FromBody] ProductModel updatedProduct)
        {
            try
            {
                var product = await _productsService.UpdateProductAsync(productId, updatedProduct);
                return Ok(product);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
    }
}
