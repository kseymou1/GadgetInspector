
using GadgetInspector.Server.Models.Inspections;

namespace GadgetInspector.Server.DataProviders.Inspections;

public interface IInspectionDataProvider
{
    /// <summary>
    /// AddScheduledDateToGadgetAsync and AssignTechnicianToGadgetAsync are very similar to each other
    /// They could probably be turned into a generic UpdateField method
    /// But really they should become one method called by a single front-end action
    /// to update both TechnicianId and ScheduledDate at the same time. So we won't go too crazy right now
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task AssignTechnicianToGadgetAsync(AssignTechnicianToGadgetRequest request);

    /// <summary>
    /// AddScheduledDateToGadgetAsync and AssignTechnicianToGadgetAsync are very similar to each other
    /// They could probably be turned into a generic UpdateField method
    /// But really they should become one method called by a single front-end action
    /// to update both TechnicianId and ScheduledDate at the same time. So we won't go too crazy right now
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task AddScheduledDateToGadgetAsync(AddScheduledDateToGadgetRequest request);
    Task<IList<GetForTechnicianResult>> GetForTechnicianAsync(int technicianId);
    Task MarkCompleteAsync(MarkCompleteRequest request);
}
