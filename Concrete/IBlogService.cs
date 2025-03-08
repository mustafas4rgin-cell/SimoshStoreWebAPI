using App.Data.Entities;
using SimoshStore;

namespace SimoshStoreAPI;

public interface IBlogService
{
    Task<IEnumerable<BlogEntity>> BlogSection();
    Task<IEnumerable<BlogEntity>> GetBlogsAsync();
    Task<BlogEntity> GetBlogByIdAsync(int id);
    Task<IServiceResult> UpdateBlogAsync(int id,BlogDTO dto);
    Task<IServiceResult> DeleteBlogAsync(int id);
    Task<IServiceResult> CreateBlogAsync(BlogDTO dto);
}
