using FastPay.Transactions.Domain.Resources.v1;

namespace FastPay.Transactions.Domain.Entities.v1;

public sealed class Account
{
    public Guid Id { get; set; }

    public string? ClientId { get; set; }

    public string? AccountId { get; set; } = Constants.AccountNumber;

    public decimal InitialBalance { get; set; }

    public decimal CreditLimit { get; set; }

    public void SetIdentity(string clientId, string accountId)
    {
        ClientId = clientId;
        AccountId = accountId ;
    }
}