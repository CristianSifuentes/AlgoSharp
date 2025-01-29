// Interface for account operations
public interface IAccount {
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    string GetAccountDetails();
}