// Transaction processor
public class TransactionProcessor
{
    public event EventHandler<TransactionEventArgs> TransactionProcessed;

    public void ProcessDeposit(IAccount account, decimal amount)
    {
        account.Deposit(amount);
        TransactionProcessed?.Invoke(this, new TransactionEventArgs(account.AccountNumber, amount, "Deposit"));
    }

    public void ProcessWithdrawal(IAccount account, decimal amount)
    {
        account.Withdraw(amount);
        TransactionProcessed?.Invoke(this, new TransactionEventArgs(account.AccountNumber, amount, "Withdrawal"));
    }
}