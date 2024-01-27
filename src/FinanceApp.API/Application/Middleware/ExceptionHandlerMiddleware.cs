using FinanceApp.API.Application.Models.Exceptions;
using Microsoft.Data.SqlClient;

namespace FinanceApp.API.Application.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                string exceptionMessage = "An error occured. Please contact to support.";
                if (ex is NotFoundException)
                {
                    context.Response.StatusCode = 404;
                    exceptionMessage = ex.Message;
                }

                else if (ex is CustomerAlreadyExistException)
                {
                    context.Response.StatusCode = 409;
                    exceptionMessage = ex.Message;
                }

                await context.Response.WriteAsync(exceptionMessage);

            }
        }
    }
}
