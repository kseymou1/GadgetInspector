using GadgetInspector.Core.Domain.Inspections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GadgetInspector.Data.Mapping.Inspections;

internal class InspectionMap : BaseEntityTypeConfiguration<Inspection>
{
    public override void Configure(EntityTypeBuilder<Inspection> builder)
    {
        base.Configure(builder);

        //We are keeping it simple here, using just date instead of datetime
        builder.Property(x => x.ScheduledDate).HasColumnType("date");
        builder.Property(x => x.CompletionDate).HasColumnType("date");

        builder.Property(x => x.ScheduledDate).HasMaxLength(1000);
        builder.Property(x => x.InspectorNotes).HasMaxLength(1000);
    }
}
