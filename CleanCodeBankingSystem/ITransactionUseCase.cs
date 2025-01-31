// Input port (use case interface)
public interface ITransactionUseCase{
    void Execute(string accountNumber, decimal amount);
}