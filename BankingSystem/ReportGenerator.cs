// Report generator for account summaries
public class ReportGenerator
{
    public async Task GenerateReportAsync(IEnumerable<IAccount> accounts)
    {
        Console.WriteLine("Generating report...");
        await Task.Delay(1000); // Simulate report generation time

        var report = accounts.Select(account => account.GetAccountDetails());
        Console.WriteLine("\n--- Account Summary Report ---");
        foreach (var line in report)
        {
            Console.WriteLine(line);
        }
    }
}