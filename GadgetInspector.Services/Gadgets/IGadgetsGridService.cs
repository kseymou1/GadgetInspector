using GadgetInspector.Core.Domain.Gadgets.ProcedureResults;
using GadgetInspector.Services.Gadgets.Support;

namespace GadgetInspector.Services.Gadgets;

public interface IGadgetsGridService : IBaseService
{
    Task<IList<GadgetsGridItem>> GetGridItemsAsync(GadgetsGridRequest request);
}
