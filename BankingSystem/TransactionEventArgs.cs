// Event arguments for transaction events
public class TransactionEventArgs : EventArgs
{
    public string AccountNumber { get; }
    public decimal Amount { get; }
    public string TransactionType { get; }

    public TransactionEventArgs(string accountNumber, decimal amount, string transactionType)
    {
        AccountNumber = accountNumber;
        Amount = amount;
        TransactionType = transactionType;
    }
}