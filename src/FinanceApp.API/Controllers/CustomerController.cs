using Azure;
using FinanceApp.API.Application.Models.Exceptions;
using FinanceApp.API.Application.Models.Payloads.Customer;
using FinanceApp.API.Application.Services.Customer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FinanceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;


        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [SwaggerOperation(Summary = "Create customer", OperationId = "Create customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {

            var customer =
                await _customerService.CreateCustomerAsync(request.IdNumber, request.Name, request.Surname);
            return CreatedAtRoute("GetCustomer", new { uuid = customer.UUID }, customer);

        }

        [HttpGet("{uuid}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves customer by uuid", OperationId = "Get Customer by uuid")]
        public async Task<IActionResult> GetCustomer(Guid uuid)
        {
            var customer = await _customerService.GetCustomerByUUIDAsync(uuid);
            return Ok(customer);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves all customers", OperationId = "Get all customers")]
        public async Task<IActionResult> GetCustomer()
        {
            var customer = await _customerService.GetAllCustomersAsync();
            return Ok(customer);
        }

        [HttpGet("idnumber/{idNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves customer by identity number", OperationId = "Get Customer by id number")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Deletes customer", OperationId = "Delete customer")]
        public async Task<IActionResult> DeleteCustomer(Guid uuid)
        {
            var success = await _customerService.DeleteCustomerAsync(uuid);

            return NoContent();
        }

        [HttpPut("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update customer name,surname", OperationId = "Update customer")]
        public async Task<IActionResult> UpdateCustomer(Guid uuid, [FromBody] UpdateCustomerRequest request)
        {

            var customer = await _customerService.UpdateCustomerAsync(uuid, request.Name, request.Surname);

            return Ok(customer);

        }
    }
}
