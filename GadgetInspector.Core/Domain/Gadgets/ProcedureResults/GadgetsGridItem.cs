namespace GadgetInspector.Core.Domain.Gadgets.ProcedureResults;

public class GadgetsGridItem
{
    public int GadgetId { get; set; }
    public string GadgetName { get; set; } = null!;
    public string GadgetTypeName { get; set; } = null!;
    public DateTime? LastInspectedDate { get; set; }
    public DateTime DueDate { get; set; }
    public int DaysRemaining { get; set; }
    public int? ScheduledInspectionId { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public string? ScheduledTechnicianName { get; set; }
}
