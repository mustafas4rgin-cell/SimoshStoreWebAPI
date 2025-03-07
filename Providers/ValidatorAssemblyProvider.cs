using SimoshStore;
using SimoshStoreAPI;

public static class ValidatorAssemblyProvider
{
    public static Type[] GetValidatorAssemblies() 
    {
        return new[]
        {
            typeof(RegisterDtoValidator),
            typeof(CategoryDtoValidator),
            typeof(BlogDtoValidator),
            typeof(ProductCommentDtoValidator),
            typeof(BlogCommentDtoValidator),
            typeof(ContactDtoValidator),
            typeof(OrderDtoValidator),
            typeof(ProductImageDtoValidator),
            typeof(ProductDtoValidator)
        };
    }
}
