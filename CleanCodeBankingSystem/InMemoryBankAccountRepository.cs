// In-memory repository implementation

public class InMemoryBankAccountRepository : IBankAccountRepository
{
    public void Add(BankAccount bankAccount)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BankAccount> GetAll()
    {
        throw new NotImplementedException();
    }

    public BankAccount GetByAccountNumber(string accountNumber)
    {
        throw new NotImplementedException();
    }

    public void Update(BankAccount bankAccount)
    {
        throw new NotImplementedException();
    }
}