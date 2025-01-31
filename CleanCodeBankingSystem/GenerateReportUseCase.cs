// Generate report use code
public class GenerateReportUseCase
{
    private readonly IBankAccountRepository _repository;

    public GenerateReportUseCase(IBankAccountRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<string> Execute(){
        var accounts = _repository.GetAll();
         return (IEnumerable<string>)accounts;
    }
}