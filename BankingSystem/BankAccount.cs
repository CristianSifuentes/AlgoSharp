// Abstract base class for common account properties
public abstract class BankAccount : IAccount
{
    public string AccountNumber { get; } = "12345"; // NOT in the interface
    public string AccountHolder { get; }
    protected decimal Balance { get; private set; }
    protected BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Deposit amount must be positive.");
        Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Withdrawal amount must be positive.");
        if (amount > Balance) throw new InvalidOperationException("Insufficient funds.");
        Balance -= amount;
    }

    public abstract string GetAccountDetails();
}
