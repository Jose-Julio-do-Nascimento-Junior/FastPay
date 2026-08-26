namespace FastPay.Transactions.Domain.Contracts.v1.Repositories;

public interface IClientSequenceRepository
{
    Task<string> GenerateClientIdAsync(CancellationToken cancellationToken);
}