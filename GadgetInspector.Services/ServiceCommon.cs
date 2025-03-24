namespace GadgetInspector.Services;

public class ServiceCommon(MainDbContext mainDbContext) : IServiceCommon
{
    public MainDbContext MainDbContext { get; private set; } = mainDbContext;
}
