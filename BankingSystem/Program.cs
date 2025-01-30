class Program
{
    static async Task Main(string[] args)
    {
        // Create accounts
        var savings = new SavingsAccount("SA12345", "Alice", 1000);
        var checking = new CheckingAccount("CA67890", "Bob", 500);

        // Transaction processor
        var transactionProcessor = new TransactionProcessor();
        transactionProcessor.TransactionProcessed += (sender, e) =>
        {
            Console.WriteLine($"Transaction Alert: {e.TransactionType} of {e.Amount:C} on account {e.AccountNumber}");
        };

        // Perform transactions
        transactionProcessor.ProcessDeposit(savings, 200);
        transactionProcessor.ProcessWithdrawal(checking, 100);

        // Generate report
        var accounts = new List<IAccount> { savings, checking };
        var reportGenerator = new ReportGenerator();
        await reportGenerator.GenerateReportAsync(accounts);
    }
}