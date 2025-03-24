namespace GadgetInspector.Services;

public abstract class BaseService(IServiceCommon serviceCommon) : IBaseService
{
    #region Properties
    public IServiceCommon ServiceCommon { get; private set; } = serviceCommon;

    //Convenience properties
    protected MainDbContext MainDbContext => ServiceCommon.MainDbContext;
    #endregion
}
