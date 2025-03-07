using FluentValidation;
using SimoshStore;

namespace SimoshStoreAPI;


    public class ProductImageDtoValidator : AbstractValidator<ProductImageDTO>
    {
        public ProductImageDtoValidator()
        {
            RuleFor(x => x.ProductId).NotNull().WithMessage("Product is required");
            RuleFor(x => x.Url).NotNull().WithMessage("Image is required");
        }
    }

