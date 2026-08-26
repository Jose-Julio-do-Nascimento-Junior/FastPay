using FastPay.Transactions.Domain.Entities.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastPay.Transactions.Infra.Data.Sql.DataBaseMappings.v1;

public sealed class AccountsMapping : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> entity)
    {
        entity.ToTable("Tb_Accounts");

        entity.HasKey(account => account.Id);

        entity.Property(account => account.Id).HasColumnName("id");

        entity.Property(account => account.ClientId)
            .HasColumnName("client_id")
            .HasColumnType("nvarchar(10)");

        entity.Property(account => account.AccountId)
            .HasColumnName("account_id")
            .HasColumnType("nvarchar(10)");

        entity.Property(account => account.InitialBalance)
            .HasColumnName("balance")
            .HasColumnType("decimal(18,2)");

        entity.Property(account => account.CreditLimit)
            .HasColumnName("credit_limit")
            .HasColumnType("decimal(18,2)");
    }
}