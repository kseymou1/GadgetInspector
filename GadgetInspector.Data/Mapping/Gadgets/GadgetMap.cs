using GadgetInspector.Core.Domain.Gadgets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GadgetInspector.Data.Mapping.Gadgets;

internal class GadgetMap : BaseEntityTypeConfiguration<Gadget>
{
    public override void Configure(EntityTypeBuilder<Gadget> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasMaxLength(7).IsFixedLength();
        builder.HasIndex(x => x.Name).IsUnique();
    }
}
