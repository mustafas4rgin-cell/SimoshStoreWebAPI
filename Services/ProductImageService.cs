using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using SimoshStore;

namespace SimoshStoreAPI;

public class ProductImageService : IProductImageService
{
    private readonly IDataRepository _Repository;
    public ProductImageService(IDataRepository repository)
    {
        _Repository = repository;
    }
    public async Task<ProductImageEntity> GetProductImageByIdAsync(int id)
    {
        var productImage = await _Repository.GetAll<ProductImageEntity>()
                                .Include(i => i.Product)
                                .FirstOrDefaultAsync(i => i.Id == id);
        if (productImage is null)
        {
            throw new Exception("Product image not found");
        }
        return productImage;
    }
    public async Task<IServiceResult> UpdateProductImageAsync(ProductImageDTO dto, int id)
    {
        var productImage = await _Repository.GetByIdAsync<ProductImageEntity>(id);
        if (productImage is null)
        {
            return new ServiceResult(false, "Product image not found");
        }
        productImage.Url = dto.Url;
        productImage.ProductId = dto.ProductId;
        await _Repository.UpdateAsync(productImage);
        return new ServiceResult(true, "Product image updated successfully");
    }
    public async Task<IServiceResult> DeleteProductImageAsync(int id)
    {
        var productImage = await _Repository.GetByIdAsync<ProductImageEntity>(id);
        if(productImage is null)
        {
            return new ServiceResult(false,"Product image not found");
        }
        await _Repository.DeleteAsync<ProductImageEntity>(id);
        return new ServiceResult(true, "Product image deleted successfully");
    }
    public async Task<IServiceResult> CreateProductImageAsync(ProductImageDTO dto)
    {
        var productImage = MappingHelper.MappingProductImage(dto);
        if (productImage is null)
        {
            return new ServiceResult(false, "Product image is null");
        }
        if (productImage.ProductId <= 0)
        {
            return new ServiceResult(false, "Product image product id is invalid");
        }
        if (productImage.Url is null)
        {
            productImage.Url = "https://via.placeholder.com/1500";
        }
        await _Repository.AddAsync(productImage);
        return new ServiceResult(true, "Product image created successfully");
    }
    public async Task<IEnumerable<ProductImageEntity>> GetProductImages()
    {
        var images = await _Repository.GetAll<ProductImageEntity>()
                            .Include(i => i.Product)
                            .ToListAsync();
        if (images == null)
        {
            throw new Exception("No images found");
        }
        return images;
    }
    public async Task<IEnumerable<ProductImageEntity>> GetProductImagesByProductId(int productId)
    {
        var images = await _Repository.GetAll<ProductImageEntity>().Where(i => i.ProductId == productId).ToListAsync();
        if (images == null)
        {
            throw new Exception("No images found");
        }
        return images;
    }
}
