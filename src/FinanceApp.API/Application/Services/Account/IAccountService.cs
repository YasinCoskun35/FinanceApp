namespace FinanceApp.API.Application.Services.Account
{
    public interface IAccountService
    {
        Task<Domain.Entities.Account> AddAccountAsync(Guid customerId, string alias, string currency);
        Task<bool> DeleteAccountAsync(Guid accountId);
        Task<Domain.Entities.Account> UpdateAccountAsync(Guid accountId, string alias, string currency);
        Task<List<Domain.Entities.Account>> GetCustomerAccountsByIdentityNumberAsync(string identityNumber);

    }

}
