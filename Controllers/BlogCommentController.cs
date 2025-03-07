using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStore;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public BlogCommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("/api/blogcomments")]
        public async Task<IActionResult> GetBlogComments()
        {
            try
            {
                var comments = await _commentService.GetBlogComments();
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("/api/blogcomments/{id}")]
        public async Task<IActionResult> GetBlogComment(int id)
        {
            try
            {
                var comment = await _commentService.GetBlogCommentById(id);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("/api/delete/blogcomment/{id}")]
        public async Task<IActionResult> DeleteBlogComment(int id)
        {
            try
            {
                var result = await _commentService.DeleteBlogComment(id);
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
        [HttpPut("/api/update/blogcomment/{id}")]
        public async Task<IActionResult> UpdateBlogComment([FromBody] BlogCommentDTO comment,[FromRoute] int id)
        {
            var result = await _commentService.UpdateBlogComment(comment,id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPost("/api/create/blogcomment")]
        public async Task<IActionResult> CreateBlogComment([FromBody] BlogCommentDTO comment)
        {
            var result = await _commentService.CreateBlogComment(comment);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
