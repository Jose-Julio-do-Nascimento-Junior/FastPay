using FastPay.Core.Api.Http.Controllers;
using FastPay.Core.Api.Http.Models;
using FastPay.Core.Domain.Contracts;
using FastPay.Core.Domain.Models;
using FastPay.Transactions.Domain.Commands.v1.CreateAccounts;
using System.Net;

namespace FastPay.Transactions.Api.Controllers.v1;

[Route("api/v1/accounts")]
public class AccountsController : BaseController
{
    public AccountsController(
        IMediator bus,
        IDomainContextNotifications domainNotificationContext,
        ApplicationSettings settings) : base(bus, domainNotificationContext, settings)
    {
    }

    [HttpPost]
    [ProducesResponseType(typeof(Response), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(Response), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateAccountsAsync(
       CreateAccountsCommand command,
       CancellationToken cancellationToken)
    {
        return await ExecuteAsync(command, cancellationToken);
    }
}