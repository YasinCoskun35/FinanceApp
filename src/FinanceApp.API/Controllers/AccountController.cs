using FinanceApp.API.Application.Models.Payloads.Account;
using FinanceApp.API.Application.Models.Payloads.Customer;
using FinanceApp.API.Application.Services.Account;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<CreateAccountRequest> _createAccountRequestValidator;
        private readonly IValidator<UpdateAccountRequest> _updateAccountRequestValidator;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] CreateAccountRequest request)
        {
            var account = await _accountService.AddAccountAsync(request.CustomerId, request.Alias, request.Currency);
            return CreatedAtRoute("GetAccount", new { uuid = account.UUID }, account);
        }

        [HttpDelete("{uuid}")]
        public async Task<IActionResult> DeleteAccount(Guid uuid)
        {
            var success = await _accountService.DeleteAccountAsync(uuid);

            return NoContent();
        }

        [HttpPut("{uuid}")]
        public async Task<IActionResult> UpdateAccount(Guid uuid, [FromBody] UpdateAccountRequest request)
        {

            var account = await _accountService.UpdateAccountAsync(uuid, request.Alias, request.Currency);

            return Ok(account);


        }
        [HttpGet("{idNumber}/accounts")]
        public async Task<IActionResult> GetCustomerAccounts(string idNumber)
        {
            var accounts = await _accountService.GetCustomerAccountsByIdentityNumberAsync(idNumber);

            return Ok(accounts);
        }
    }
}
