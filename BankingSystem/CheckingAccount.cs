// Derived class for checking accounts
public class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountNumber, string accountHolder, decimal initialBalance)
        : base(accountNumber, accountHolder, initialBalance) { }

    public override string GetAccountDetails()
    {
        return $"[Checking Account] {AccountHolder} - {AccountNumber}, Balance: {Balance:C}";
    }
}