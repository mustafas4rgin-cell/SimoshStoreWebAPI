using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStore;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductImages()
        {
            try 
            {
                var productImages = await _productImageService.GetProductImages();
                return Ok(productImages);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductImageDTO dto)
        {
            var result = await _productImageService.CreateProductImageAsync(dto);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(dto);
        }
        [HttpDelete("/productimage/delete/{id}")]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            var result = await _productImageService.DeleteProductImageAsync(id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPut("/productimage/update/{id}")]
        public async Task<IActionResult> UpdateProductImage([FromBody] ProductImageDTO dto,[FromRoute] int id)
        {
            var result = await _productImageService.UpdateProductImageAsync(dto,id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpGet("/productimage/{productId}")]
        public async Task<IActionResult> GetProductImagesById(int productId)
        {
            try 
            {
                var productImages = await _productImageService.GetProductImageByIdAsync(productId);
                return Ok(productImages);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
