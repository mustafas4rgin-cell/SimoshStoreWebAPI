using App.Data.Entities;
using SimoshStore;

namespace SimoshStoreAPI;

public interface ICategoryService
{
    Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
    Task<IServiceResult> CreateCategoryAsync(CategoryDTO category);
    Task<IServiceResult> DeleteCategoryAsync(int id);
    Task<IServiceResult> UpdateCategoryAsync(CategoryDTO category, int id);
    public Task<CategoryEntity> GetCategoryByIdAsync(int id);
    public Task<BlogCategoryEntity> GetBlogCategoryByIdAsync(int id);
    public Task<IEnumerable<BlogCategoryEntity>> GetBlogCategories();
}
