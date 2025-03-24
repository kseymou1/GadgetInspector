using GadgetInspector.Core.Domain.Gadgets;
using GadgetInspector.Core.Domain.Technicians;
using GadgetInspector.Core.Domain.Users;

namespace GadgetInspector.Core.Domain.Inspections;

public class Inspection : BaseEntity
{
    //Honestly this logic is all sorts of flawed.
    //It probably makes more sense for Technician and ScheduledDate to be required and not null
    //But this is a demo for fun, and I already made the grid.
    //So let's force this logic to match the grid behavior, where they can add the Technician and ScheduledDate one at a time
    //For this workaround, we are thinking that only one incomplete future inspection can exist for each gadget
    //So we are free to assign the Technician and the ScheduledDate independently

    //public required DateTime ScheduledDate { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? CompletionDate { get; set; }

    public required int GadgetId { get; set; }
    public Gadget Gadget { get; set; } = null!;

    //public required int TechnicianId { get; set; }
    public int? TechnicianId { get; set; }
    public Technician Technician { get; set; } = null!;

    public required bool IsComplete { get; set; }
    public bool? IsPassed { get; set; }

    /// <summary>
    /// These are optional
    /// </summary>
    public string? SchedulerNotes { get; set; } = null!;

    /// <summary>
    /// InspectorNotes is nullable before inspection
    /// Technician must affirmatively state the equipment is OK or a reason why not in order to complete inspection
    /// </summary>
    public string? InspectorNotes { get; set; } = null!;

    /// <summary>
    /// Should EditedByUserId be required?  Maybe nullable if these are automatically system assigned
    /// Would we have a flag for that? IsSystemAssigned = true?
    /// Or maybe a service account User record?
    /// </summary>
    public int? EditedByUserId { get; set; }
    public User EditedByUser { get; set; } = null!;
}

