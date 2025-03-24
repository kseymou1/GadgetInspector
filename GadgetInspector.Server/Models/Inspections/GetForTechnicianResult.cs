namespace GadgetInspector.Server.Models.Inspections;

public class GetForTechnicianResult
{
    public int InspectionId { get; set; }
    public string GadgetName { get; set; } = null!;
    public string GadgetTypeName { get; set; } = null!;
    public DateTime? ScheduledDate { get; set; }
}
