using FinanceApp.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.API.Data.Seeds
{
    public class AccountSeed : IEntityTypeConfiguration<Account>
    {
        private readonly Account[] _accounts = new Account[]
       {
            new Account(){UUID= Guid.NewGuid(),Alias= "Normal Account",Currency= "TRY",CustomerId= Guid.Parse("87D39D2F-4B9C-470F-A47F-9F0E3F4C38DA")},
            new Account(){UUID= Guid.NewGuid(),Alias= "USD Account",Currency= "USD",CustomerId= Guid.Parse("87D39D2F-4B9C-470F-A47F-9F0E3F4C38DA")}
         };
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(_accounts);
        }
    }
}
