using FastPay.Core.Domain.Models;

namespace FastPay.Transactions.Domain.Commands.v1.CreateAccounts;

public sealed class CreateAccountsCommand : Command
{
    public string ClientId { get; set; } = string.Empty;

    public decimal InitialBalance { get; set; }

    public decimal CreditLimit { get; set; }
}