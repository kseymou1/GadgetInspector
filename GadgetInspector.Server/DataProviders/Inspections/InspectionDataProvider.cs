using GadgetInspector.Core.Domain.Inspections;
using GadgetInspector.Server.Models.Inspections;
using GadgetInspector.Services.Inspections;
using Microsoft.EntityFrameworkCore;

namespace GadgetInspector.Server.DataProviders.Inspections;

public class InspectionDataProvider(
    IInspectionService inspectionService) : IInspectionDataProvider
{
    public async Task AssignTechnicianToGadgetAsync(AssignTechnicianToGadgetRequest request)
    {
        Inspection incompleteInspection = await inspectionService.GetIncompleteInspectionForGadgetAsync(request.GadgetId);

        incompleteInspection.TechnicianId = request.TechnicianId;

        await inspectionService.UpdateAsync(incompleteInspection);
    }

    public async Task AddScheduledDateToGadgetAsync(AddScheduledDateToGadgetRequest request)
    {
        Inspection incompleteInspection = await inspectionService.GetIncompleteInspectionForGadgetAsync(request.GadgetId);

        incompleteInspection.ScheduledDate = request.ScheduledDate;

        await inspectionService.UpdateAsync(incompleteInspection);
    }

    public async Task<IList<GetForTechnicianResult>> GetForTechnicianAsync(int technicianId)
    {
        return await inspectionService.GetEntities(EntityType.Untracked)
            .Include(x => x.Gadget).ThenInclude(x => x.GadgetType)
            .Where(x => !x.IsComplete && x.TechnicianId == technicianId) //&& x.ScheduledDate.HasValue
            .Select(x => new GetForTechnicianResult
            {
                InspectionId = x.Id,
                GadgetName = x.Gadget.Name,
                GadgetTypeName = x.Gadget.GadgetType.Name,
                ScheduledDate = x.ScheduledDate
            }).ToListAsync();
    }

    public async Task MarkCompleteAsync(MarkCompleteRequest request)
    {
        Inspection inspection = await inspectionService.GetById(request.InspectionId, EntityType.Tracked).SingleAsync();

        ValidateMarkComplete(inspection);

        inspection.IsComplete = true;
        inspection.IsPassed = true;
        inspection.CompletionDate = request.CompletedDate;
        inspection.InspectorNotes = request.Notes;

        await inspectionService.UpdateAsync(inspection);
    }

    #region MarkCompleteAsync Support
    private static void ValidateMarkComplete(Inspection inspection)
    {
        if (inspection.IsComplete) throw new InvalidOperationException("Inspection already completed.");
    }
    #endregion
}
