using GadgetInspector.Core.Domain.Gadgets.ProcedureResults;
using GadgetInspector.Server.DataProviders.Gadgets;
using GadgetInspector.Services.Gadgets.Support;

namespace GadgetInspector.Server.Controllers.Gadgets;

public class GadgetController(
    IGadgetDataProvider gadgetDataProvider) : BaseController
{
    [HttpPost]
    [Route(NamedAction)]
    public async Task<IList<GadgetsGridItem>> GetGriditems(GadgetsGridRequest request)
    {
        return await gadgetDataProvider.GetGridItemsAsync(request);
    }
}
