namespace FinanceApp.API.Domain.Entities
{
    public class Account
    {
        public Guid UUID { get; set; }
        public Customer Customer { get; set; }
        public string Alias { get; set; }
        public string Currency { get; set; }
    }
}
