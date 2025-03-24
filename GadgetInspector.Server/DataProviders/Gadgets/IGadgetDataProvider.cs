using GadgetInspector.Core.Domain.Gadgets.ProcedureResults;
using GadgetInspector.Services.Gadgets.Support;

namespace GadgetInspector.Server.DataProviders.Gadgets;

public interface IGadgetDataProvider
{
    Task<IList<GadgetsGridItem>> GetGridItemsAsync(GadgetsGridRequest request);
}
