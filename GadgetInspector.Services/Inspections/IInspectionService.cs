using GadgetInspector.Core.Domain.Inspections;

namespace GadgetInspector.Services.Inspections;

public interface IInspectionService : IEntityService<Inspection>
{
    Task<Inspection> GetIncompleteInspectionForGadgetAsync(int gadgetId);
}
