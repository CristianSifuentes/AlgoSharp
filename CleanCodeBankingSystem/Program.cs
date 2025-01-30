class Program
{
    static async Task Main(string[] args)
    {
        // Set up dependencies
        var repository = new InMemoryBankAccountRepository();
        var depositUseCase = new DepositMoneyUseCase();
        var reportUseCase = new GenerateReportUseCase();
    }

}