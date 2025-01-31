class Program
{
    static async Task Main(string[] args)
    {
        // Set up dependencies
        var repository = new InMemoryBankAccountRepository();
        var depositUseCase = new DepositMoneyUseCase(repository);
        var reportUseCase = new GenerateReportUseCase(repository);
        
        // Add initial accounts
        repository.Add(new BankAccount("1234", "Alice", 1000));
        repository.Add(new BankAccount("67890", "Bob", 500));
    
    }

}