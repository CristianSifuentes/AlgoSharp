class Program
{
    static async Task Main(string[] args)
    {
        // Set up dependencies
        var repository = new InMemoryBankAccountRepository();
        var depositUseCase = new DepositMoneyUseCase(repository);
        var reportUseCase = new GenerateReportUseCase(repository);
        
        // Add initial accounts
        repository.Add(new BankAccount("12345", "Alice", 1000));
        repository.Add(new BankAccount("67890", "Bob", 500));
        
        // Perform deposit
        Console.WriteLine("Depositing $200 into Alice's account...");
        depositUseCase.Execute("12345", 200);

        // Generate report
        Console.WriteLine("\nGenerating Report...");
        var report = reportUseCase.Execute();
        
        foreach(var line in report){
            Console.WriteLine(line);
        }
        
        // Simulate async work
        Console.WriteLine("\nSimulating async operation...");
        await Task.Delay(1000);
        Console.WriteLine("Async operation completed.");

    }


}