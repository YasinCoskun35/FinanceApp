using FinanceApp.API.Application.Models.Payloads.Customer;
using FluentValidation;

namespace FinanceApp.API.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
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

            RuleFor(request => request.IdNumber)
                .NotNull()
                .WithMessage("Id number can not be empty.")
                .Length(11)
                .WithMessage("Please enter a valid id number");
        }
    }
}
