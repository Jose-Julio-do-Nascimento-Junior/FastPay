using FastPay.Transactions.Domain.Entities.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastPay.Transactions.Infra.Data.Sql.DataBaseMappings.v1;

public sealed class ClientSequenceMapping : IEntityTypeConfiguration<ClientSequence>
{
    public void Configure(EntityTypeBuilder<ClientSequence> entity)
    {
        entity.ToTable("Client_Sequences");

        entity.HasKey(account => account.Id);

        entity.Property(account => account.Id).HasColumnName("id");

        entity.Property(account => account.LastNumber).HasColumnName("last_number");

        entity.HasData(
        new
        {
           Id = 1,
           LastNumber = 0
        });
    }
}