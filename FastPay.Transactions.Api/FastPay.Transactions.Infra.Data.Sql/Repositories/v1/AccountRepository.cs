using FastPay.Transactions.Domain.Contracts.v1.Repositories;
using FastPay.Transactions.Domain.Entities.v1;
using FastPay.Transactions.Infra.Data.Sql.DataBase.v1;
using Microsoft.Extensions.Logging;

namespace FastPay.Transactions.Infra.Data.Sql.Repositories.v1;

public sealed class AccountRepository : IAccountRepository
{
    private readonly DataContext _dataContext;
    private readonly ILogger<AccountRepository> _logger;

    public AccountRepository(DataContext dataContext, ILogger<AccountRepository> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    public async Task<Account> CreateAccountAsync(Account account, CancellationToken cancellationToken)
    {
        await _dataContext.Account.AddAsync(account, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return account;
    }
}