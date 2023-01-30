using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Request;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure.Interfaces;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ICommandStore<AccountMovementCommandRequest, AccountMovementCommandResponse> _accountMovementCommandStore;
        private readonly IQueryStore<AccountBalanceQueryRequest, AccountBalanceQueryResponse> _accountBalanceQueryStore;

        public AccountController(ICommandStore<AccountMovementCommandRequest, AccountMovementCommandResponse> accountMovementCommandStore,
                                IQueryStore<AccountBalanceQueryRequest, AccountBalanceQueryResponse> accountBalanceQueryStore)
        {
            _accountMovementCommandStore = accountMovementCommandStore;
            _accountBalanceQueryStore = accountBalanceQueryStore;
        }

        [HttpPost("Movement")]
        public async Task<IActionResult> Movement([FromBody] AccountMovementCommandRequest request)
        {
            var response = await _accountMovementCommandStore.Execute(request);

            if (response.ErrorMessage != null)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Movement);
        }

        [HttpGet("Balance/{accountId}")]
        public async Task<IActionResult> Balance(Guid accountId)
        {
            var response = await _accountBalanceQueryStore.Execute(new AccountBalanceQueryRequest { AccountId = accountId });

            return Ok(response.Balance);
        }
    }
}
