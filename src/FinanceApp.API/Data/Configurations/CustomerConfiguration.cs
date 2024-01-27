using FinanceApp.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.API.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.UUID);

            builder.Property(c => c.UUID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            
            builder.Property(c => c.IdNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasIndex(c => c.IdNumber)
                .IsUnique();

            builder.Property(c => c.Name)
                .HasMaxLength(50);

            builder.Property(c => c.Surname)
                .HasMaxLength(50);

            builder.HasMany(c => c.Accounts)
                .WithOne(a => a.Customer);
        }
    }
}
