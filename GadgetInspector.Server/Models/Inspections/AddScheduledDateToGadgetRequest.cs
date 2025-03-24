namespace GadgetInspector.Server.Models.Inspections;

public class AddScheduledDateToGadgetRequest
{
    public int GadgetId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public int EditedByUserId { get; set; }
}