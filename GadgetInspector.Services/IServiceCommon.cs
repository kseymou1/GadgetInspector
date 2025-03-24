namespace GadgetInspector.Services;

/// <summary>
/// Interface for common dependencies for all classes that inherit from an IEntityService 
/// implementation.  Saves the developer from having to pass multiple constructor parameters.
/// </summary>
public interface IServiceCommon
{
    MainDbContext MainDbContext { get; }
}
