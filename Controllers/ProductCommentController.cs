using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStore;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class ProductCommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public ProductCommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductComments()
        {
            try
            {
                var comments = await _commentService.GetProductComments();
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductComment(int id)
        {
            try
            {
                var comment = await _commentService.GetProductCommentById(id);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductComment(int id)
        {
            try
            {
                var result = await _commentService.DeleteProductComment(id);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCommentEntity(ProductCommentDTO dto, int id)
        {
            try
            {
                var result = await _commentService.UpdateProductComment(dto, id);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("/api/create/productcomment")]
        public async Task<IActionResult> CreateProductComment([FromBody] ProductCommentDTO dto)
        {
            var result = await _commentService.CreateProductCommentAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
