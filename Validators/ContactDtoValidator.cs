using FluentValidation;
using SimoshStore;

namespace SimoshStoreAPI;


    public class ContactDtoValidator : AbstractValidator<ContactDTO>
    {
        public ContactDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.Message).NotNull().WithMessage("Message is required");
        }
    }

