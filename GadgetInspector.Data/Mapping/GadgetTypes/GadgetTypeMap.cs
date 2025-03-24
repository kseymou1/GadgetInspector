using GadgetInspector.Core.Domain.GadgetTypes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GadgetInspector.Data.Mapping.GadgetTypes;

internal class GadgetTypeMap : BaseEntityTypeConfiguration<GadgetType>
{
    public override void Configure(EntityTypeBuilder<GadgetType> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasMaxLength(100);
        builder.HasIndex(x => x.Name).IsUnique();
    }
}
