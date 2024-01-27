namespace FinanceApp.API.Application.Models.Exceptions
{
    public class CustomerNotFoundException: NotFoundException
    {
        public CustomerNotFoundException() : base("Customer not found.")
        {
        }
    }
}
