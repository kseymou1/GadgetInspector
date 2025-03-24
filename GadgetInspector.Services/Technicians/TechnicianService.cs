using GadgetInspector.Core.Domain.Technicians;

namespace GadgetInspector.Services.Technicians;

public class TechnicianService(IServiceCommon serviceCommon) : BaseEntityService<Technician>(serviceCommon), ITechnicianService
{
}
