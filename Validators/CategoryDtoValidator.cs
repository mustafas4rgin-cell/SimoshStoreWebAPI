using FluentValidation;
using SimoshStore;

namespace SimoshStoreAPI;


    public class CategoryDtoValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Category name is required");
        }
    }

