// Repository interface for bank accounts
public interface IBankAccountRepository{
    void Add (BankAccount bankAccount);
    void Update(BankAccount bankAccount);
    IEnumerable<BankAccount> GetAll();
    BankAccount GetByAccountNumber(string accountNumber);

}
