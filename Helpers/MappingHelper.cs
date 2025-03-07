using App.Data.Entities;
using SimoshStoreAPI;

namespace SimoshStore;

public class MappingHelper
{
    public static UserEntity RegisterDtoToUserEntity(RegisterDto dto)
    {
        HashingHelper.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
        return new UserEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone,
            Email = dto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
    }
    public static BlogCommentEntity MappingBlogCommentEntity(BlogCommentDTO dto)
    {
        return new BlogCommentEntity
        {
            Comment = dto.Comment,
            Name = dto.Name,
            Email = dto.Email,
            BlogId = dto.BlogId
        };
    }
    public static ProductCommentEntity MappingProductCommentEntity(ProductCommentDTO dto)
    {
        return new ProductCommentEntity
        {
            Text = dto.Text,
            StarCount = dto.StarCount,
            IsConfirmed = dto.IsConfirmed
        };
    }
    public static UserEntity MappingUserEntity(UserDTO dto)
    {
        HashingHelper.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
        return new UserEntity
        {
            Address = dto.Address,
            Email = dto.Email,
            FirstName = dto.FirstName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Phone = dto.Phone,
            RoleId = dto.RoleId,
            LastName = dto.LastName

        };
    }
    public static OrderEntity MappingOrderEntity(OrderDTO dto)
    {
        return new OrderEntity
        {
            Address = dto.Address,
            OrderCode = dto.OrderCode,
            UserId = dto.UserId
        };
    }
    public static BlogCategoryEntity MappingBlogCategoryEntity(BlogCategoryEntityDTO dto)
    {
        return new BlogCategoryEntity
        {
            Name = dto.Name,
        };
    }
    public static BlogEntity MappingBlogEntity(BlogDTO dto)
    {
        return new BlogEntity
        {
            Title = dto.Title,
            Content = dto.Content,
            ImageUrl = dto.ImageUrl,
            UserId = dto.userId,
        };
    }
    public static ContactFormEntity MappingContactForm(ContactDTO dto)
    {
        return new ContactFormEntity
        {
            Name = dto.Name,
            Email = dto.Email,
            Message = dto.Message
        };
    }
    public static CategoryEntity MappingCategory(CategoryDTO dto)
    {
        return new CategoryEntity
        {
            Color = dto.Color,
            IconCssClass = dto.IconCssClass,
            Name = dto.Name,
            imageUrl = dto.ImageUrl
        };
    }
    public static ProductEntity MappingProduct(ProductDTO dto)
    {
        return new ProductEntity
        {
            CategoryId = dto.CategoryId,
            Description = dto.Description,
            DiscountId = dto.DiscountId,
            Price = dto.Price,
            Name = dto.Name,
            StockAmount = dto.StockAmount,
            Enabled = dto.Enabled,
        };
    }

    public static ProductImageEntity MappingProductImage(ProductImageDTO dto)
    {
        return new ProductImageEntity
        {
            Url = dto.Url,
            ProductId = dto.ProductId
        };
    }
}
