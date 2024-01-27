namespace FinanceApp.API.Application.Models.Payloads.Account
{
    public class UpdateAccountRequest
    {
        public string Alias { get; set; }
        public string Currency { get; set; }
    }
}
