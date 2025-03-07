using FluentValidation;
using SimoshStore;

namespace SimoshStoreAPI;


    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotNull().WithMessage("Last name is required");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.Phone).NotNull().WithMessage("Phone is required");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        }
    }

