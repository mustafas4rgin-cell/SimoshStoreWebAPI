using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public BlogCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("/api/blogcategories")]
        public async Task<IActionResult> GetBlogCategories()
        {
            var blogCategories = await _categoryService.GetBlogCategories();
            return Ok(blogCategories);
        }
        [HttpGet("/api/blogcategories/{id}")]
        public async Task<IActionResult> GetBlogCategory(int id)
        {
            var blogCategory = await _categoryService.GetBlogCategoryByIdAsync(id);
            return Ok(blogCategory);
        }
    }
}
