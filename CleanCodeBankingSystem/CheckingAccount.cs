// Derived class for checking accounts
public class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountNumber, string accountHolder, decimal initialBalance) : base(accountNumber, accountHolder, initialBalance)
    {
    }
}