using FinanceApp.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.API.Data.Seeds
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        private readonly Customer[] _customers = new Customer[]
        {
            new Customer(){UUID=  Guid.Parse("87D39D2F-4B9C-470F-A47F-9F0E3F4C38DA"),IdNumber= "12345678901",Name= "Yasin",Surname= "Coskun"},
        };
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(_customers);
        }
    }
}
