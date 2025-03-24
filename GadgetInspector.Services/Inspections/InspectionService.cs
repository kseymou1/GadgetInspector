using GadgetInspector.Core.Domain.Inspections;
using Microsoft.EntityFrameworkCore;

namespace GadgetInspector.Services.Inspections;

public class InspectionService(IServiceCommon serviceCommon) : BaseEntityService<Inspection>(serviceCommon), IInspectionService
{
    public async Task<Inspection> GetIncompleteInspectionForGadgetAsync(int gadgetId)
    {
        //Honestly this logic is all sorts of flawed.
        //It probably makes more sense for Technician and ScheduledDate to be required and not null
        //But this is a demo for fun, and I already made the grid.
        //So let's force this logic to match the grid behavior, where they can add the Technician and ScheduledDate one at a time
        //For this workaround, we are thinking that only one incomplete future inspection can exist for each gadget
        //So we are free to assign the Technician and the ScheduledDate independently

        Inspection? currentIncompleteInspection = await Entities.Where(x => x.GadgetId == gadgetId && !x.IsComplete).SingleOrDefaultAsync();
        if (currentIncompleteInspection is not null) return currentIncompleteInspection;

        Inspection newIncompleteInspection = new()
        {
            GadgetId = gadgetId,
            IsComplete = false
        };

        await InsertAsync(newIncompleteInspection);
        return newIncompleteInspection;
    }
}
