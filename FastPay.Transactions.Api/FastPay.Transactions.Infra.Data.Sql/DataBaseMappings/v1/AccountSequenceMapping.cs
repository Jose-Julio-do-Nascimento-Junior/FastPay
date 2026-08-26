using FastPay.Transactions.Domain.Entities.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastPay.Transactions.Infra.Data.Sql.DataBaseMappings.v1;

public sealed class AccountSequenceMapping : IEntityTypeConfiguration<AccountSequence>
{
    public void Configure(EntityTypeBuilder<AccountSequence> entity)
    {
        entity.ToTable("Account_Sequences");

        entity.HasKey(account => account.ClientId);

        entity.Property(account => account.ClientId).HasColumnName("client_id");
        entity.Property(account => account.LastNumber).HasColumnName("last_number");
    }
}