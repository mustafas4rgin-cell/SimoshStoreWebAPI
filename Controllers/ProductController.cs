using System.Threading.Tasks;
using App.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimoshStore;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("/api/bestproducts")]
        public async Task<IActionResult> BestProducts()
        {
            var products = await _productService.BestProductsAsync();
            return Ok(products);
        }
        [HttpGet("/api/products")]
        public async Task<IActionResult> GetProducts()
        {
            try 
            {
                var products = await _productService.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("/api/create/product")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            var result = await _productService.CreateProductAsync(product);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(product);
        }
        [HttpDelete("/api/delete/product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPut("/api/update/product/{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO product,[FromRoute] int id)
        {
            var result = await _productService.UpdateProductAsync(product,id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(product);
        }
        [HttpGet("/api/products/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if(product is null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }
    }
}
