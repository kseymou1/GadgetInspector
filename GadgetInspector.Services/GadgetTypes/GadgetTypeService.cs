using GadgetInspector.Core.Domain.GadgetTypes;

namespace GadgetInspector.Services.GadgetTypes;

public class GadgetTypeService(IServiceCommon serviceCommon) : BaseEntityService<GadgetType>(serviceCommon), IGadgetTypeService
{
}
