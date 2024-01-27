namespace FinanceApp.API.Application.Models.Payloads.Account
{
    public class CreateAccountRequest
    {
        public Guid CustomerId { get; set; }
        public string Alias { get; set; }
        public string Currency { get; set; }
    }
}
