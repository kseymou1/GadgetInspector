using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GadgetInspector.Core.Domain.Gadgets.ProcedureResults;

namespace GadgetInspector.Data.Mapping.Gadgets.ProcedureResults;

internal class GadgetsGridItemMap : BaseKeylessEntityTypeConfiguration<GadgetsGridItem>
{
    public override void Configure(EntityTypeBuilder<GadgetsGridItem> builder)
    {
        base.Configure(builder);
    }
}