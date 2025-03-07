using App.Data.Entities;
using SimoshStore;

namespace SimoshStoreAPI;

public interface ICommentService
{
    Task<IEnumerable<ProductCommentEntity>> GetProductComments();
    Task<ProductCommentEntity> GetProductCommentById(int id);
    Task<IServiceResult> DeleteProductComment(int id);
    Task<IServiceResult> UpdateProductComment(ProductCommentDTO productComment, int id);
    Task<IEnumerable<BlogCommentEntity>> GetBlogComments();
    Task<BlogCommentEntity> GetBlogCommentById(int id);
    Task<IServiceResult> DeleteBlogComment(int id);
    Task<IServiceResult> UpdateBlogComment(BlogCommentDTO blogComment, int id);
    Task<IServiceResult> CreateBlogComment(BlogCommentDTO dto);
    Task<IServiceResult> CreateProductCommentAsync(ProductCommentDTO dto);

    
}
