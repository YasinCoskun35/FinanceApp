using FinanceApp.API.Application.Models.Exceptions;
using FinanceApp.API.Data.DbContexts;
using FinanceApp.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.API.Application.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly FinanceAppDbContext _context;

        public CustomerService(FinanceAppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Customer> CreateCustomerAsync(string idNumber, string name, string surname)
        {
            var customerExist = await UserExist(idNumber);
            if (customerExist)
            {
                throw new CustomerAlreadyExistException();
            }
            var customer = new Domain.Entities.Customer(idNumber, name, surname);
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Domain.Entities.Customer> GetCustomerByUUIDAsync(Guid uuid)
        {
            var customer = await _context.Customer
                .FindAsync(uuid);
            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }
            return customer;
        }

        public async Task<Domain.Entities.Customer> GetCustomerByIdentityNumberAsync(string identityNumber)
        {
            var customer = await _context.Customer
                .FirstOrDefaultAsync(c => c.IdNumber == identityNumber);
            return customer;
        }

        public async Task<List<Domain.Entities.Customer>> GetAllCustomersAsync()
        {
            var customers = await _context.Customer
                .ToListAsync();
            if (!customers.Any())
            {
                throw new CustomerNotFoundException();
            }
            return customers;
        }

        public async Task<bool> DeleteCustomerAsync(Guid uuid)
        {
            var customer = await _context.Customer.FindAsync(uuid);

            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }

            _context.Customer
                .Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Domain.Entities.Customer> UpdateCustomerAsync(Guid uuid, string name, string surname)
        {
            var customer = await _context.Customer
                .FindAsync(uuid);

            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }

            customer.UpdateDetails(name, surname);
            await _context.SaveChangesAsync();
            return customer;
        }

        private async Task<bool> UserExist(string identityNumber)
        {
            return await GetCustomerByIdentityNumberAsync(identityNumber)!=null;
        }
    }

}
