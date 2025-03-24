using GadgetInspector.Server.DataProviders.GadgetTypes;
using GadgetInspector.Server.Models.GadgetTypes;

namespace GadgetInspector.Server.Controllers.GadgetTypes;

public class GadgetTypeController(
    IGadgetTypeDataProvider gadgetTypeDataProvider) : BaseController
{
    [HttpGet]
    [Route(NamedAction)]
    public async Task<List<GadgetTypeModel>> Get()
    {
        return await gadgetTypeDataProvider.GetGadgetTypesAsync();
    }
}
