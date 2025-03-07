using FluentValidation;
using SimoshStore;

namespace SimoshStoreAPI;


    public class OrderDtoValidator : AbstractValidator<OrderDTO>
    {
        public OrderDtoValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("User is required");
            RuleFor(x => x.OrderCode).NotNull().WithMessage("Order code is required");
            RuleFor(x => x.Address).NotNull().WithMessage("Address is required");
        }
    }

