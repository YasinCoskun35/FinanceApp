using FinanceApp.API.Application.Models.Payloads.Account;
using FinanceApp.API.Application.Services.Account;
using FinanceApp.API.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace FinanceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create account for a customer",OperationId = "Add account")]
        public async Task<IActionResult> AddAccount([FromBody] CreateAccountRequest request)
        {
            var account = await _accountService.AddAccountAsync(request.CustomerId, request.Alias, request.Currency);
            return Ok(account);
        }

        [HttpDelete("{uuid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete account")]
        public async Task<IActionResult> DeleteAccount(Guid uuid)
        {
            var success = await _accountService.DeleteAccountAsync(uuid);

            return NoContent();
        }

        [HttpPut("{uuid}")]
        [ProducesResponseType(typeof(Account),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update account alias and currency")]
        public async Task<ActionResult<Account>> UpdateAccount(Guid uuid, [FromBody] UpdateAccountRequest request)
        {

            var account = await _accountService.UpdateAccountAsync(uuid, request.Alias, request.Currency);

            return Ok(account);


        }
        [HttpGet("{idNumber}/accounts")]
        [ProducesResponseType(typeof(List<Account>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves customer accounts with identity number")]
        public async Task<IActionResult> GetCustomerAccounts(string idNumber)
        {
            var accounts = await _accountService.GetCustomerAccountsByIdentityNumberAsync(idNumber);

            return Ok(accounts);
        }
    }
}
