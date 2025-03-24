using GadgetInspector.Core.Domain.Gadgets.ProcedureResults;
using GadgetInspector.Services.Gadgets;
using GadgetInspector.Services.Gadgets.Support;

namespace GadgetInspector.Server.DataProviders.Gadgets;

public class GadgetDataProvider(
    IGadgetsGridService gadgetsGridService) : IGadgetDataProvider
{
    public async Task<IList<GadgetsGridItem>> GetGridItemsAsync(GadgetsGridRequest request)
    {
        return await gadgetsGridService.GetGridItemsAsync(request);
    }
}
