using FinanceApp.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.API.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.UUID);

            builder.Property(a => a.UUID)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.CustomerId)
                .IsRequired();

            builder.Property(a => a.Currency)
                .HasMaxLength(3)
                .IsRequired();

            builder.HasOne(a => a.Customer)
                .WithMany(c => c.Accounts);
        }
    }
}
