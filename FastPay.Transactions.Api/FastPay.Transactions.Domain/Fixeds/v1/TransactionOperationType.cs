namespace FastPay.Transactions.Domain.Fixeds.v1;

public enum TransactionOperationType
{
    Credit = 1,
    Debit = 2,
    Reserve = 3,
    Capture = 4,
    Reversal = 5,
    Transfer = 6
}