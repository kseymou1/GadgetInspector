using GadgetInspector.Core.Domain.Technicians;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GadgetInspector.Data.Mapping.Technicians;

internal class TechnicianMap : BaseEntityTypeConfiguration<Technician>
{
    public override void Configure(EntityTypeBuilder<Technician> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasMaxLength(100);
        builder.HasIndex(x => x.Name).IsUnique();
    }
}
