using GadgetInspector.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GadgetInspector.Data.Mapping;

internal abstract class BaseEntityTypeConfiguration<T>
    : IEntityTypeConfiguration<T> where T : BaseEntity
{
    #region Methods

    //IEntityTypeConfiguration method.
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        //Make tables temporal by default.
        //Table name determined by DbSet<T> property name on MainDbContext.
        Configure(builder, isTemporal: true);
    }

    public virtual void Configure(EntityTypeBuilder<T> builder, bool isTemporal)
    {
        builder.ToTable(tableBuilder => tableBuilder.IsTemporal(isTemporal));
    }
    #endregion
}
