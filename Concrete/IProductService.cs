using App.Data.Entities;
using SimoshStore;

namespace SimoshStoreAPI;

public interface IProductService
{
    Task<IEnumerable<ProductEntity>> PopularProductsAsync(int? take);
    Task<IEnumerable<ProductEntity>> GetProductsAsync();
    Task<IServiceResult> CreateProductAsync(ProductDTO product);
    Task<IServiceResult> DeleteProductAsync(int id);
    Task<IServiceResult> UpdateProductAsync(ProductDTO product, int id);
    Task<ProductEntity> GetProductByIdAsync(int id);
    Task<IEnumerable<ProductEntity>> BestProductsAsync();
}
