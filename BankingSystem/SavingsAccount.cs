// Derived class for savings accounts
public class SavingsAccount : BankAccount
{
    private const decimal MinimumBalance = 100;

    public SavingsAccount(string accountNumber, string accountHolder, decimal initialBalance)
        : base(accountNumber, accountHolder, initialBalance)
    {
        if (initialBalance < MinimumBalance)
            throw new ArgumentException($"Initial balance must be at least {MinimumBalance}.");
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < MinimumBalance)
            throw new InvalidOperationException("Cannot withdraw below minimum balance.");
        base.Withdraw(amount);
    }

    public override string GetAccountDetails()
    {
        return $"[Savings Account] {AccountHolder} - {AccountNumber}, Balance: {Balance:C}";
    }
}