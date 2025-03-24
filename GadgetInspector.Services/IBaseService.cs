namespace GadgetInspector.Services;

public interface IBaseService
{
    /// <summary>
    /// Interface that captures everything we want to offer commonly.
    /// </summary>
    IServiceCommon ServiceCommon { get; }
}
