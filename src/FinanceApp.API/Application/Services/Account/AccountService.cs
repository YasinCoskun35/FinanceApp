using FinanceApp.API.Application.Models.Exceptions;
using FinanceApp.API.Application.Services.Customer;
using FinanceApp.API.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.API.Application.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly FinanceAppDbContext _context;
        private readonly ICustomerService _customerService;

        public AccountService(FinanceAppDbContext context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        public async Task<Domain.Entities.Account> AddAccountAsync(Guid customerGuid, string alias, string currency)
        {
            var customer = await _customerService.GetCustomerByUUIDAsync(customerGuid);

            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }

            var account = new Domain.Entities.Account(customerGuid, alias,currency);
         

            _context.Account.Add(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<bool> DeleteAccountAsync(Guid accountId)
        {
            var account = await _context.Account.FindAsync(accountId);

            if (account == null)
            {
                throw new AccountNotFoundException();
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Domain.Entities.Account> UpdateAccountAsync(Guid accountId, string alias, string currency)
        {
            var account = await _context.Account.FindAsync(accountId);

            if (account == null)
            {
                throw new AccountNotFoundException();
            }

            account.Alias = alias ?? account.Alias;
            account.Currency = currency ?? account.Currency;

            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<List<Domain.Entities.Account>> GetCustomerAccountsByIdentityNumberAsync(string identityNumber)
        {
            var customer=await _customerService.GetCustomerByIdentityNumberAsync(identityNumber);
            if (customer==null)
            {
                throw new CustomerNotFoundException();
            }
            var accounts = await _context.Account.Where(acc=>acc.CustomerId==customer.UUID).Include(acc=>acc.Customer).ToListAsync();

            return accounts;
        }
    }

}
