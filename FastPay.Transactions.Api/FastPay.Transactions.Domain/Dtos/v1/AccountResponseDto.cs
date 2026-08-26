namespace FastPay.Transactions.Domain.Dtos.v1;

public sealed record AccountResponseDto
{
    public string? ClientId { get; init; }

    public string? AccountId { get; init; }

    public float InitialBalance { get; init; }

    public float CreditLimit { get; init; }
}