// Abstract base class for common account properties
public abstract class BankAccount : IAccount
{
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