namespace FinanceApp.API.Application.Models.Exceptions
{
    public class AccountNotFoundException:NotFoundException
    {
        public AccountNotFoundException() : base("No account has been found.")
        {
        }
    }
}
