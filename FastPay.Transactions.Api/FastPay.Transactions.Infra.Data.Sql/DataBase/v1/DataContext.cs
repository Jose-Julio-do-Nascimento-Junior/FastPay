using FastPay.Transactions.Domain.Entities.v1;
using FastPay.Transactions.Infra.Data.Sql.DataBaseMappings.v1;
using Microsoft.EntityFrameworkCore;

namespace FastPay.Transactions.Infra.Data.Sql.DataBase.v1;

public sealed class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Account> Account { get; set; }

    public DbSet<ClientSequence> ClientSequences { get; set; }

    public DbSet<AccountSequence> AccountSequences { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AccountsMapping());
        modelBuilder.ApplyConfiguration(new ClientSequenceMapping());
        modelBuilder.ApplyConfiguration(new AccountSequenceMapping());
    }
}