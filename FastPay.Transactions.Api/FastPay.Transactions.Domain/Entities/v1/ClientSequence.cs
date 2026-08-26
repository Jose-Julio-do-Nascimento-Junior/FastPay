namespace FastPay.Transactions.Domain.Entities.v1;

public sealed class ClientSequence
{
    public int Id { get; private set; }

    public int LastNumber { get; private set; }

    public void ClientIncrement()
    {
        LastNumber++;
    }
}