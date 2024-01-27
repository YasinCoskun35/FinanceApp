using System.Text.Json.Serialization;

namespace FinanceApp.API.Domain.Entities
{
    public class Account
    {
        public Guid UUID { get; set; }
        [JsonIgnore]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Alias { get; set; }
        public string Currency { get; set; }

        public Account()
        {
            
        }
        public Account(Guid customerId, string alias, string currency)
        {
            CustomerId=customerId;
            Alias=alias;
            Currency=currency;
        }
    }
}
