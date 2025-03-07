using FluentValidation;
using SimoshStore;

namespace SimoshStoreAPI;

public class BlogCommentDtoValidator : AbstractValidator<BlogCommentDTO>
    {
        public BlogCommentDtoValidator()
        {
            RuleFor(x => x.Comment).NotNull().WithMessage("Comment is required");
            RuleFor(x => x.BlogId).NotNull().WithMessage("BlogId is required");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
        }
    }

