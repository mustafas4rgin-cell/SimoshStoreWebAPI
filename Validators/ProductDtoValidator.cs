using FluentValidation;
using SimoshStore;

namespace SimoshStoreAPI;


    public class ProductDtoValidator : AbstractValidator<ProductDTO>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Price).NotNull().WithMessage("Price is required");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("Category is required");
            RuleFor(x => x.Description).NotNull().WithMessage("Description is required");
            RuleFor(x => x.StockAmount).NotNull().WithMessage("Stock is required");
            //RuleFor(x => x.SellerId).NotNull().WithMessage("Seller is required");
        }
    }

