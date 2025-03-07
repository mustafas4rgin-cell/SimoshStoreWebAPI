using App.Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SimoshStore;

namespace SimoshStoreAPI;

public class CommentService : ICommentService
{
    private readonly IDataRepository _dataRepository;
    private readonly IValidator<ProductCommentDTO> _productCommentValidator;
    private readonly IValidator<BlogCommentDTO> _blogCommentValidator;
    public CommentService(IValidator<ProductCommentDTO> productCommentValidator, IValidator<BlogCommentDTO> blogCommentValidator, IDataRepository dataRepository)
    {
        _productCommentValidator = productCommentValidator;
        _blogCommentValidator = blogCommentValidator;
        _dataRepository = dataRepository;
    }
    public async Task<IEnumerable<ProductCommentEntity>> GetProductComments()
    {
        var comments = await _dataRepository.GetAll<ProductCommentEntity>()
                            .Include(c => c.Product)
                            .Include(c => c.User)
                            .ToListAsync();
        if(comments is null)
        {
            throw new Exception("No comments found");
        }
        return comments;
    }
    public async Task<IServiceResult> CreateProductCommentAsync(ProductCommentDTO dto)
    {
        var validationResult = _productCommentValidator.Validate(dto);
        if(!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        }
        var comment = MappingHelper.MappingProductCommentEntity(dto);
        await _dataRepository.AddAsync(comment);
        return new ServiceResult(true, "Comment created successfully");
    }
    public async Task<ProductCommentEntity> GetProductCommentById(int id)
    {
        var comment = await _dataRepository.GetAll<ProductCommentEntity>()
                            .Include(c => c.Product)
                            .Include(c => c.User)
                            .FirstOrDefaultAsync(c => c.Id == id);
        if(comment is null)
        {
            throw new Exception("Comment not found");
        }
        return comment;
    }
    public async Task<IServiceResult> DeleteProductComment(int id)
    {
        var comment = await _dataRepository.GetByIdAsync<ProductCommentEntity>(id);
        if(comment is null)
        {
            return new ServiceResult(false, "Comment not found");
        }
        await _dataRepository.DeleteAsync<ProductCommentEntity>(id);
        return new ServiceResult(true, "Comment deleted successfully");
    }
    public async Task<IServiceResult> UpdateProductComment(ProductCommentDTO dto, int id)
    {
        var comment = await GetProductCommentById(id);
        if(comment is null)
        {
            return new ServiceResult(false, "Comment not found");
        }
        var validationResult = _productCommentValidator.Validate(dto);
        if(!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        }
        comment.StarCount = dto.StarCount;
        comment.IsConfirmed = dto.IsConfirmed;
        await _dataRepository.UpdateAsync(comment);
        return new ServiceResult(true, "Comment updated successfully");
    }
    public async Task<IEnumerable<BlogCommentEntity>> GetBlogComments()
    {
        var comments = await _dataRepository.GetAll<BlogCommentEntity>().ToListAsync();
        if(comments is null)
        {
            throw new Exception("No comments found");
        }
        if(comments.Count == 0)
        {
            throw new Exception("No comments found");
        }
        return comments;
    }
    public async Task<IServiceResult> CreateBlogComment(BlogCommentDTO dto)
    {
        var validationResult = _blogCommentValidator.Validate(dto);
        if(!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        }
        var comment = MappingHelper.MappingBlogCommentEntity(dto);
        await _dataRepository.AddAsync(comment);
        return new ServiceResult(true, "Comment created successfully");
    }
    public async Task<BlogCommentEntity> GetBlogCommentById(int id)
    {
        var comment = await _dataRepository.GetByIdAsync<BlogCommentEntity>(id);
        if(comment is null)
        {
            throw new Exception("Comment not found");
        }
        return comment;
    }
    public async Task<IServiceResult> DeleteBlogComment(int id)
    {
        var comment = await _dataRepository.GetByIdAsync<BlogCommentEntity>(id);
        if(comment is null)
        {
            return new ServiceResult(false, "Comment not found");
        }
        await _dataRepository.DeleteAsync<BlogCommentEntity>(id);
        return new ServiceResult(true, "Comment deleted successfully");
    }
    public async Task<IServiceResult> UpdateBlogComment(BlogCommentDTO dto, int id)
    {
        var comment = await _dataRepository.GetByIdAsync<BlogCommentEntity>(id);
        if(comment is null)
        {
            return new ServiceResult(false, "Comment not found");
        }
        var validationResult = _blogCommentValidator.Validate(dto);
        if(!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        }
        comment.Comment = dto.Comment;
        comment.BlogId = dto.BlogId;
        comment.Email = dto.Email;
        comment.Name = dto.Name;
        await _dataRepository.UpdateAsync(comment);
        return new ServiceResult(true, "Comment updated successfully");
    }
           
}
