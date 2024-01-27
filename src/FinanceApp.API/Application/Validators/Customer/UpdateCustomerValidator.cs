using FinanceApp.API.Application.Models.Payloads.Customer;
using FluentValidation;

namespace FinanceApp.API.Application.Validators.Customer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(request => request.Surname)
                .NotNull()
                .WithMessage("Surname can not be empty.")
                .MinimumLength(2)
                .WithMessage("Please enter a valid surname");

            RuleFor(request => request.Name)
                .NotNull()
                .WithMessage("Name can not be empty.")
                .MinimumLength(2)
                .WithMessage("Please enter a valid name");
        }
    }
}
