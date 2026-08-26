using FastPay.Transactions.Domain.Entities.v1;

namespace FastPay.Transactions.Domain.Contracts.v1.Repositories;

public interface IAccountRepository
{
    Task<Account> CreateAccountAsync(Account account, CancellationToken cancellationToken);
}