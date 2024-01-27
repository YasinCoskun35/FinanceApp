using System.Security.AccessControl;

namespace FinanceApp.API.Domain.Entities
{
    public class Customer
    {
        public Guid UUID { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
