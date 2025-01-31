// BankAccount entity (core business logic)
public class BankAccount
{
    public string  AccountNumber { get; }
    public string AccountHolder { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string accountNumber, string accountHolder, int initialBalance){
       
       if(string.IsNullOrWhiteSpace(accountNumber)) throw new ArgumentException("Account number cannot be null.");
       if (string.IsNullOrWhiteSpace(accountHolder)) throw new ArgumentException("Account holder cannot be null.");
       if (initialBalance < 0) throw new ArgumentException("Initial balance cannot be negative.");
       AccountNumber = accountNumber;
       AccountHolder = accountHolder;
       Balance = initialBalance;
    }

    public void Deposit(decimal amount){
        if (amount <= 0) throw new ArgumentException("Deposit amount must be positive.");
        Balance += amount;
    }
    public void Withdraw(decimal amount){
        if (amount <= 0) throw new ArgumentException("Withdrawal amount must be positive.");
        if (amount > Balance) throw new InvalidOperationException("Insufficient funds.");
        Balance -= amount;
    }
}