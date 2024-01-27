using FinanceApp.API.Domain.Entities;

namespace FinanceApp.API.Application.Services.Customer
{
    public interface ICustomerService
    {
        Task<Domain.Entities.Customer> CreateCustomerAsync(string idNumber, string name, string surname);
        Task<Domain.Entities.Customer> GetCustomerByUUIDAsync(Guid uuid);
        Task<Domain.Entities.Customer> GetCustomerByIdentityNumberAsync(string identityNumber);
        Task<List<Domain.Entities.Customer>> GetAllCustomersAsync();
        Task<bool> DeleteCustomerAsync(Guid uuid);
        Task<Domain.Entities.Customer> UpdateCustomerAsync(Guid uuid,string name, string surname);
    }

}
