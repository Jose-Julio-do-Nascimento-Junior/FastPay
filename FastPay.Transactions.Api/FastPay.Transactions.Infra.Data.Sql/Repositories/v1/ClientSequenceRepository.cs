using FastPay.Transactions.Domain.Contracts.v1.Repositories;
using FastPay.Transactions.Domain.Resources.v1;
using FastPay.Transactions.Infra.Data.Sql.DataBase.v1;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Transactions.Infra.Data.Sql.Repositories.v1;

public sealed class ClientSequenceRepository : IClientSequenceRepository
{
    private readonly DataContext _dataContext;

    public ClientSequenceRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<string> GenerateClientIdAsync(CancellationToken cancellationToken)
    {
        var sequence = await _dataContext.ClientSequences.FirstOrDefaultAsync(cancellationToken);

        sequence!.ClientIncrement();

        await _dataContext.SaveChangesAsync(cancellationToken);

        return string.Format(Constants.ClientIdFormat, sequence.LastNumber);
    }
}