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
        private IProductsService _categoriesService;

        public ProductsController(IProductsService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // api/teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetCategoriesAsync(string orderBy = "Id")
        {
            try
            {
                var categories = await _categoriesService.GetProductsAsync(orderBy);
                return Ok(categories);
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
        [HttpGet("{categoryId:long}")]
        public async Task<ActionResult<ProductModel>> GetCategoryAsync(long categoryId)// public async Task<ActionResult<CategoryWithProductModel>> GetProductAsync(long teamId)
        {
            try
            {
                var team = await _categoriesService.GetProductAsync(categoryId);
                return Ok(team);
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
        public async Task<ActionResult<ProductModel>> CreateCategoryAsync([FromBody] ProductModel newCategory)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var category = await _categoriesService.CreateProductAsync(newCategory);
                return Created($"/api/categories/{category.Id}", category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpDelete("{categoryId:long}")]
        public async Task<ActionResult<bool>> DeleteCategoryAsync(long categoryId)
        {
            try
            {
                var result = await _categoriesService.DeleteProductAsync(categoryId);
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

        [HttpPut("{categoryId:long}")]
        public async Task<ActionResult<ProductModel>> UpdateCategoryAsync(long categoryId, [FromBody] ProductModel updatedCategory)
        {
            try
            {
                /*if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(updatedTeam.City) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }*/

                var category = await _categoriesService.UpdateProductAsync(categoryId, updatedCategory);
                return Ok(category);
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
