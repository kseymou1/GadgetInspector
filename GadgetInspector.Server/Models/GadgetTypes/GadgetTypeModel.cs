namespace GadgetInspector.Server.Models.GadgetTypes;

public class GadgetTypeModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int InspectionIntervalDays { get; set; }
}
