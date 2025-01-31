// Generate report use code
public class GenerateReportUseCase
{
    private IBankAccountRepository  repository;

    public GenerateReportUseCase(IBankAccountRepository repository)
    {
        this.repository = repository;
    }
}