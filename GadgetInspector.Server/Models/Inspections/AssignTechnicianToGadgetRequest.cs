namespace GadgetInspector.Server.Models.Inspections;

public class AssignTechnicianToGadgetRequest
{
    public int GadgetId { get; set; }
    public int TechnicianId { get; set; }
    public int EditedByUserId { get; set; }
}
