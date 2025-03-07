using FluentValidation;
using SimoshStore;

namespace SimoshStoreAPI;

    public class BlogDtoValidator : AbstractValidator<BlogDTO>
    {
        public BlogDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title is required");
            RuleFor(x => x.Content).NotNull().WithMessage("Content is required");
            RuleFor(x => x.ImageUrl).NotNull().WithMessage("Image is required");
        }
    }

