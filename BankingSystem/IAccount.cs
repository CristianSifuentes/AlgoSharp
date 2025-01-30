// Interface for account operations
public interface IAccount
{
    string AccountNumber { get; }
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    string GetAccountDetails();
}
