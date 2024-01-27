namespace FinanceApp.API.Application.Models.Exceptions
{
    public class CustomerAlreadyExistException:Exception
    {
        public CustomerAlreadyExistException()
        {
        }

        public CustomerAlreadyExistException(string message="Customer is already exist.") : base(message)
        {
        }

        public CustomerAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
