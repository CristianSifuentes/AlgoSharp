// Abstract base class for common account properties
public abstract class BankAccount : IAccount
{
    private string accountNumber;
    private string accountHolder;
    private decimal initialBalance;

    protected BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
    {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this.initialBalance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        throw new NotImplementedException();
    }

    public string GetAccountDetails()
    {
        throw new NotImplementedException();
    }

    public void Withdraw(decimal amount)
    {
        throw new NotImplementedException();
    }
}