using FinanceApp.API.Application.Middleware;
using FinanceApp.API.Application.Models.Payloads.Account;
using FinanceApp.API.Application.Models.Payloads.Customer;
using FinanceApp.API.Application.Services.Account;
using FinanceApp.API.Application.Services.Customer;
using FinanceApp.API.Application.Validators.Account;
using FinanceApp.API.Application.Validators.Customer;
using FluentValidation;

namespace FinanceApp.API.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddFinanceAppServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IValidator<CreateCustomerRequest>, CreateCustomerValidator>();
            serviceCollection.AddScoped<IValidator<UpdateCustomerRequest>, UpdateCustomerValidator>();
            serviceCollection.AddScoped<IValidator<CreateAccountRequest>, CreateAccountValidator>();
            serviceCollection.AddScoped<IValidator<UpdateAccountRequest>, UpdateAccountValidator>();
            serviceCollection.AddScoped<IAccountService, AccountService>();
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            return serviceCollection;
        }
        public static IApplicationBuilder UseFinanceExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
            return applicationBuilder;
        }
    }
}
