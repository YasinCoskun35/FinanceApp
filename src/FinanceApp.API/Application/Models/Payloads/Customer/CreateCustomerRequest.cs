namespace FinanceApp.API.Application.Models.Payloads.Customer
{
    public class CreateCustomerRequest
    {
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
