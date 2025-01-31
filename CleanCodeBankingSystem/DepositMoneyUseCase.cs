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
        var account = _repository.GetByAccountNumber(accountNumber);
        if (account == null) throw new ArgumentException("Account not found.");
        account.Deposit(amount);
    }
}