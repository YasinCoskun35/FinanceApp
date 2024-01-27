using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace FinanceApp.API.Domain.Entities
{
    public class Customer
    {
        public Guid UUID { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Customer()
        {
            
        }
        public Customer(string idNumber, string name, string surname)
        {
            IdNumber = idNumber;
            Name = name;
            Surname = surname;
        }

        public void UpdateDetails(string name, string surname)
        {
            if (!String.IsNullOrEmpty(name))
            {
                Name = name;
            }
            if (!String.IsNullOrEmpty(surname))
            {
                Surname = surname;
            }
        }
        [JsonIgnore]
        public  List<Account> Accounts { get; set; }
    }
}
