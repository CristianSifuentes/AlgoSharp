// Deposit use case
public class DepositMoneyUseCase: ITransactionUseCase
{
    private IBankAccountRepository  repository;

    public DepositMoneyUseCase(IBankAccountRepository  repository)
    {
        this.repository = repository;
    }

    public void Execute(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }
}