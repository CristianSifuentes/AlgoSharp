// In-memory repository implementation

public class InMemoryBankAccountRepository : IBankAccountRepository
{
    private readonly Dictionary<string, BankAccount> _accounts = new();
    public void Add(BankAccount bankAccount)
    {
        if (_accounts.ContainsKey(bankAccount.AccountNumber))
            throw new ArgumentException("Account already exists.");
        _accounts[bankAccount.AccountNumber] = bankAccount;
    }

    public IEnumerable<BankAccount> GetAll()
    {
        return _accounts.Values;
    }

    public BankAccount GetByAccountNumber(string accountNumber)
    {
        _accounts.TryGetValue(accountNumber, out var account);
        return account;
    }

    public void Update(BankAccount bankAccount){
        if (!_accounts.ContainsKey(bankAccount.AccountNumber))
            throw new ArgumentException("Account not found.");
        _accounts[bankAccount.AccountNumber] = bankAccount;
    }
}