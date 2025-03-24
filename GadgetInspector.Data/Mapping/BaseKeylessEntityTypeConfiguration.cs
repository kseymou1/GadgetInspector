using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GadgetInspector.Data.Mapping;

internal abstract class BaseKeylessEntityTypeConfiguration<T>
    : IEntityTypeConfiguration<T> where T : class
{
    #region IEntityTypeConfiguration Method

    //Base entity type configuration for keyless entity types.
    //These will typically be search results sourced from a stored procedure or view.
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        //Pass null as viewName when using this with stored procedures.
        Configure(builder, viewName: null);
    }

    public virtual void Configure(EntityTypeBuilder<T> builder, string? viewName = null)
    {
        builder.HasNoKey();

        //Use "ToView" to indicate it's read-only - EF will not attempt to
        //create a table for it.
        builder.ToView(viewName);
    }
    #endregion
}
