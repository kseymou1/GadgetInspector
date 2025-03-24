namespace GadgetInspector.Core.Domain.GadgetTypes;

public class GadgetType : BaseEntity
{
    public required string Name { get; set; }
    public required int InspectionIntervalDays { get; set; }
}
