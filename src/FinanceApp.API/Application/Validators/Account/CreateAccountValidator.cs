using FinanceApp.API.Application.Models.Payloads.Account;
using FluentValidation;

namespace FinanceApp.API.Application.Validators.Account
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountValidator()
        {
            RuleFor(request => request.Currency)
                .Length(3)
                .WithMessage("Please enter a valid currency code.")
                .NotEmpty()
                .NotNull()
                .WithMessage("Currency info is required.");

            RuleFor(request => request.Alias)
                .NotEmpty()
                .NotNull()
                .WithMessage("Account alias info is required.");

            RuleFor(request => request.CustomerId)
                .NotNull()
                .WithMessage("Customer info is required.");
        }
    }
}
