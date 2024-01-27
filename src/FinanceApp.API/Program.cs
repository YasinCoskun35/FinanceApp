using System.Reflection;
using FinanceApp.API.Application.Middleware;
using FinanceApp.API.Application.Models.Payloads.Account;
using FinanceApp.API.Application.Models.Payloads.Customer;
using FinanceApp.API.Application.Services.Account;
using FinanceApp.API.Application.Services.Customer;
using FinanceApp.API.Application.Validators.Account;
using FinanceApp.API.Application.Validators.Customer;
using FinanceApp.API.Data.DbContexts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddDbContext<FinanceAppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(FinanceAppDbContext)).GetName().Name);
    });
});

//Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IValidator<CreateCustomerRequest>, CreateCustomerValidator>();
builder.Services.AddScoped<IValidator<UpdateCustomerRequest>, UpdateCustomerValidator>(); 
builder.Services.AddScoped<IValidator<CreateAccountRequest>, CreateAccountValidator>();
builder.Services.AddScoped<IValidator<UpdateAccountRequest>, UpdateAccountValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<FinanceAppDbContext>();
    dataContext.Database.Migrate();
}
app.Run();
