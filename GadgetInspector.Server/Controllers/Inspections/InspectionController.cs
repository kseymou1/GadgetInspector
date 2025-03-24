
using GadgetInspector.Server.DataProviders.Inspections;
using GadgetInspector.Server.Models.Inspections;

namespace GadgetInspector.Server.Controllers.Inspections;

public class InspectionController(
    IInspectionDataProvider inspectionDataProvider) : BaseController
{
    [HttpPost]
    [Route(NamedAction)]
    public async Task<IActionResult> AssignTechnicianToGadget(AssignTechnicianToGadgetRequest request)
    {
        request.EditedByUserId = GetUserId();
        await inspectionDataProvider.AssignTechnicianToGadgetAsync(request);
        return Ok();
    }

    [HttpPost]
    [Route(NamedAction)]
    public async Task<IActionResult> AddScheduledDateToGadget(AddScheduledDateToGadgetRequest request)
    {
        request.EditedByUserId = GetUserId();
        await inspectionDataProvider.AddScheduledDateToGadgetAsync(request);
        return Ok();
    }

    [HttpGet]
    [Route(NamedAction + "/{technicianId}")]
    public async Task<IList<GetForTechnicianResult>> GetForTechnician(int technicianId)
    {
        //Would validate here that the logged in user is the technician in question, or an admin with access
        return await inspectionDataProvider.GetForTechnicianAsync(technicianId);
    }

    [HttpPost]
    [Route(NamedAction)]
    public async Task<IActionResult> MarkComplete(MarkCompleteRequest request)
    {
        request.EditedByUserId = GetUserId();
        await inspectionDataProvider.MarkCompleteAsync(request);
        return Ok();
    }
}
