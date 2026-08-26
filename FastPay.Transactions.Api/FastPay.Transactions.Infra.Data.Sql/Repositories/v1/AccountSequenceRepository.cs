using FastPay.Transactions.Domain.Contracts.v1.Repositories;
using FastPay.Transactions.Domain.Entities.v1;
using FastPay.Transactions.Domain.Resources.v1;
using FastPay.Transactions.Infra.Data.Sql.DataBase.v1;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Transactions.Infra.Data.Sql.Repositories.v1;

public sealed class AccountSequenceRepository : IAccountSequenceRepository
{
    private readonly DataContext _dataContext;

    public AccountSequenceRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<string> GenerateAccountIdAsync(string clientId, CancellationToken cancellationToken)
    {
        var sequence = await _dataContext.AccountSequences.FirstOrDefaultAsync(
            account => account.ClientId == clientId,cancellationToken);

        if (sequence is null)
        {
            sequence = new AccountSequence(clientId, (int)decimal.One);

            await _dataContext.AccountSequences.AddAsync(sequence, cancellationToken);
        }
        else
        {
            sequence.AccountIncrement();
        }

        await _dataContext.SaveChangesAsync(cancellationToken);

        return string.Format(Constants.AccountFormat, sequence.LastNumber);
    }
}