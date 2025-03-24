using GadgetInspector.Server.Models.GadgetTypes;

namespace GadgetInspector.Server.DataProviders.GadgetTypes;

public interface IGadgetTypeDataProvider
{
    Task<List<GadgetTypeModel>> GetGadgetTypesAsync();
}
