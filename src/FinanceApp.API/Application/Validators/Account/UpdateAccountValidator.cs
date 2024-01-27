using FinanceApp.API.Application.Models.Payloads.Account;
using FluentValidation;

namespace FinanceApp.API.Application.Validators.Account
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateAccountValidator()
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
        }
    }
}
