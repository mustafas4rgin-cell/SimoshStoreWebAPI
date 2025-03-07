using App.Data.Entities;
using SimoshStore;

namespace SimoshStoreAPI;

public interface IProductImageService
{
    public Task<IEnumerable<ProductImageEntity>> GetProductImagesByProductId(int productId);
    public Task<IEnumerable<ProductImageEntity>> GetProductImages( );
    Task<IServiceResult> CreateProductImageAsync(ProductImageDTO dto);
    Task<IServiceResult> DeleteProductImageAsync(int id);
    Task<IServiceResult> UpdateProductImageAsync(ProductImageDTO dto, int id);
    Task<ProductImageEntity> GetProductImageByIdAsync(int id);
}
