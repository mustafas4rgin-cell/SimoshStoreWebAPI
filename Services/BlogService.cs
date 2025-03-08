using App.Data.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SimoshStore;

namespace SimoshStoreAPI;

public class BlogService : IBlogService
{
    private readonly IDataRepository _dataRepository;
    private readonly IValidator<BlogDTO> _validator;
    public BlogService(IValidator<BlogDTO> validator,  IDataRepository dataRepository)
    {
        _validator = validator;
        _dataRepository = dataRepository;
    }
    public async Task<IEnumerable<BlogEntity>> BlogSection()
    {
        var blogs = await _dataRepository.GetAll<BlogEntity>()
                    .Include(B => B.User)
                    .Include(B => B.Comments)
                    .Include(B => B.BlogCategories)
                    .Take(6)
                    .ToListAsync();
        return blogs;
    }
    public async Task<IEnumerable<BlogEntity>> GetBlogsAsync()
    {
        var blogs = await _dataRepository.GetAll<BlogEntity>()
                                        .Include(B => B.User)
                                        .Include(B => B.Comments)
                                        .Include(B => B.BlogCategories)
                                        .ToListAsync();
        if(blogs is null)
        {
            throw new NullReferenceException("There is no blog.");
        }
        return blogs;
    }
    public async Task<BlogEntity> GetBlogByIdAsync(int id)
    {
        var blogs = await GetBlogsAsync();
        var blog = blogs.FirstOrDefault(B => B.Id==id);
        if(blog == null)
        {
            throw new NullReferenceException($"There is no blog with that {id}");
        }
        return blog;
    }
    public async Task<IServiceResult> UpdateBlogAsync(int id, BlogDTO dto)
    {
        var updatedBlog = await GetBlogByIdAsync(id);
        if(updatedBlog is null)
        {
            return new ServiceResult(false,"There is no blog with that id.");
        }
        var validationResult = _validator.Validate(dto);
        if(!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        } 
        updatedBlog.Title = dto.Title;
        updatedBlog.Content = dto.Content;
        var user = await _dataRepository.GetByIdAsync<UserEntity>(dto.userId);
        if(user is null)
        {
            return new ServiceResult(false,"There is no user with that ID");
        }
        updatedBlog.UserId = dto.userId;
        updatedBlog.ImageUrl = dto.ImageUrl;
        await _dataRepository.UpdateAsync(updatedBlog);
        return new ServiceResult(true,"Blog updated successfully.");
    }
    public async Task<IServiceResult> CreateBlogAsync(BlogDTO dto)
    {
        var validationResult = _validator.Validate(dto);
        if(!validationResult.IsValid)
        {
            return new ServiceResult(false, validationResult.Errors.First().ErrorMessage);
        }
        var blog = MappingHelper.MappingBlogEntity(dto);
        await _dataRepository.AddAsync(blog);
        return new ServiceResult(true,"Blog added successfully");
    }
    public async Task<IServiceResult> DeleteBlogAsync(int id)
    {
        var blog = await GetBlogByIdAsync(id);
        if(blog is null)
        {
            return new ServiceResult(false,"There is no blog with that ID.");
        }
        await _dataRepository.DeleteAsync<BlogEntity>(blog.Id);
        return new ServiceResult(true,"Blog deleted successfully.");
    }
}
