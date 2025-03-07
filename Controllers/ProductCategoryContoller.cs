using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStore;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryContoller : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public ProductCategoryContoller(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("/api/categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if(categories is null)
            {
                return NotFound();
            }
            return Ok(categories);
        }
        [HttpPost("/api/create/category")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO category)
        {
            var result = await _categoryService.CreateCategoryAsync(category);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(category);
        }
        [HttpDelete("/api/delete/category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPut("/api/update/category/{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDTO category, int id)
        {
            var result = await _categoryService.UpdateCategoryAsync(category, id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpGet("/api/categories/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if(category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
