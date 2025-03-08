using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStore;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet("/api/blog-section")]
        public async Task<IActionResult> BlogSection()
        {
            var blogs = await _blogService.BlogSection();
            return Ok(blogs);
        }
        
        [HttpGet("/api/blogs")]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs =await _blogService.GetBlogsAsync();
            return Ok(blogs);
        }
        [HttpGet("/api/blogs/{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            return Ok(blog);
        }
        [HttpPut("/api/update/blog/{id}")]
        public async Task<IActionResult> UpdateBlog([FromBody]BlogDTO dto,int id)
        {
            var result = await _blogService.UpdateBlogAsync(id,dto);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPost("/api/create/blog")]
        public async Task<IActionResult> CreateBlog([FromBody]BlogDTO dto)
        {
            var result = await _blogService.CreateBlogAsync(dto);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
