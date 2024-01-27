using FinanceApp.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinanceApp.API.Data.DbContexts
{
    public class FinanceAppDbContext:DbContext
    {
        public FinanceAppDbContext()
        {
            
        }

        public FinanceAppDbContext(DbContextOptions options):base(options)
        {
            
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
