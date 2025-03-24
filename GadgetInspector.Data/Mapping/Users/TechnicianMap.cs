using GadgetInspector.Core.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GadgetInspector.Data.Mapping.Users;

internal class UserMap : BaseEntityTypeConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).HasMaxLength(100);
        builder.HasIndex(x => x.Name).IsUnique();
    }
}
