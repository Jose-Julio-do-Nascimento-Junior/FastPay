namespace FastPay.Transactions.Domain.Contracts.v1.Repositories;

public interface IAccountSequenceRepository
{
    Task<string> GenerateAccountIdAsync(string clientId, CancellationToken cancellationToken);
}