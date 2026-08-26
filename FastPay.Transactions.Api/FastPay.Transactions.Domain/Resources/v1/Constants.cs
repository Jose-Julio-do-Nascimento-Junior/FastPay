namespace FastPay.Transactions.Domain.Resources.v1;

public static class Constants
{
    #region Input_Account
    public const string ValidClientIdFormat = @"^CLI-\d{3}$";
    public const string AccountNumber = "ACC-001";
    #endregion

    #region Output_Account
    public const string ClientIdFormat = "CLI-{0:D3}";
    public const string AccountFormat = "ACC-{0:D3}";
    #endregion
}