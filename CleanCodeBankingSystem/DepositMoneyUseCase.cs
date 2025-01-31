// Deposit use case
public class DepositMoneyUseCase:ITransactionUseCase
{
    private InMemoryBankAccountRepository repository;

    public DepositMoneyUseCase(InMemoryBankAccountRepository repository)
    {
        this.repository = repository;
    }

    public void Execute(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }
}