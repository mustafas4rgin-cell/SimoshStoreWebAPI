using FluentValidation;

namespace SimoshStoreAPI;


    public class ProductCommentDtoValidator : AbstractValidator<ProductCommentDTO>
    {
        public ProductCommentDtoValidator()
        {
            RuleFor(x => x.StarCount).InclusiveBetween(0, 5).WithMessage("Star count must be between 0 and 5");
            RuleFor(x => x.Text).NotNull().WithMessage("Comment is required");
        }
    }

