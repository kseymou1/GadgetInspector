using GadgetInspector.Core.Domain.GadgetTypes;

namespace GadgetInspector.Core.Domain.Gadgets;

public class Gadget : BaseEntity
{
    public required string Name { get; set; }

    public required int GadgetTypeId { get; set; }
    public GadgetType GadgetType { get; set; } = null!;
}

