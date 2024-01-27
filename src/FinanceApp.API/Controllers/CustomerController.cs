using FinanceApp.API.Application.Models.Exceptions;
using FinanceApp.API.Application.Models.Payloads.Customer;
using FinanceApp.API.Application.Services.Customer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IValidator<CreateCustomerRequest> _createCustomerRequestValidator;
        private readonly IValidator<UpdateCustomerRequest> _updateCustomerRequestValidator;

        public CustomerController(ICustomerService customerService, IValidator<CreateCustomerRequest> createCustomerRequestValidator, IValidator<UpdateCustomerRequest> updateCustomerRequestValidator)
        {
            _customerService = customerService;
            _createCustomerRequestValidator = createCustomerRequestValidator;
            _updateCustomerRequestValidator = updateCustomerRequestValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {

            var customer =
                await _customerService.CreateCustomerAsync(request.IdNumber, request.Name, request.Surname);
            return CreatedAtRoute("GetCustomer", new { uuid = customer.UUID }, customer);

        }

        [HttpGet("{uuid}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid uuid)
        {
            var customer = await _customerService.GetCustomerByUUIDAsync(uuid);
            return Ok(customer);
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var customer = await _customerService.GetAllCustomersAsync();
            return Ok(customer);
        }

        [HttpGet("idnumber/{idNumber}")]
        public async Task<IActionResult> GetCustomerByIdNumber(string idNumber)
        {
            var customer = await _customerService.GetCustomerByIdentityNumberAsync(idNumber);
            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }
            return Ok(customer);
        }

        [HttpDelete("{uuid}")]
        public async Task<IActionResult> DeleteCustomer(Guid uuid)
        {
            var success = await _customerService.DeleteCustomerAsync(uuid);

            return NoContent();
        }

        [HttpPut("{uuid}")]
        public async Task<IActionResult> UpdateCustomer(Guid uuid, [FromBody] UpdateCustomerRequest request)
        {

            var customer = await _customerService.UpdateCustomerAsync(uuid, request.Name, request.Surname);

            return Ok(customer);

        }
    }
}
