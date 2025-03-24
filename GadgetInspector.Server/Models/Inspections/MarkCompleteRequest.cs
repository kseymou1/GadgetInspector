namespace GadgetInspector.Server.Models.Inspections;

public class MarkCompleteRequest
{
    public int InspectionId { get; set; }
    public DateTime CompletedDate { get; set; }
    public string Notes { get; set; } = null!;
    public int EditedByUserId { get; set; }
}