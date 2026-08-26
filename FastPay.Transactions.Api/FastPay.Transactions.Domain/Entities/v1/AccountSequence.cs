namespace FastPay.Transactions.Domain.Entities.v1;

public sealed class AccountSequence
{
    public AccountSequence(string clientId, int lastNumber)
    {
        ClientId = clientId;
        LastNumber = lastNumber;
    }

    public string ClientId { get; private set; } = string.Empty;

    public int LastNumber { get; private set; }

    public void AccountIncrement()
    {
        LastNumber++;
    }
}