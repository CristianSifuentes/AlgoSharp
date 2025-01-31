// Deposit use case
public class DepositMoneyUseCase: ITransactionUseCase
{
    private readonly IBankAccountRepository  _repository;

    public DepositMoneyUseCase(IBankAccountRepository  repository)
    {
        _repository = repository;

    }

    public void Execute(string accountNumber, decimal amount)
    {
        throw new NotImplementedException();
    }
}