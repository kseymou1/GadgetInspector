using GadgetInspector.Core.Domain.Gadgets;
using GadgetInspector.Core.Domain.Gadgets.ProcedureResults;
using GadgetInspector.Core.Domain.GadgetTypes;
using GadgetInspector.Core.Domain.Inspections;
using GadgetInspector.Core.Domain.Technicians;
using GadgetInspector.Core.Domain.Users;
using GadgetInspector.Data.Converters;
using GadgetInspector.Data.Mapping.GadgetTypes;
using Microsoft.EntityFrameworkCore;

namespace GadgetInspector.Data;

public class MainDbContext : DbContext
{
    #region Properties
    //*** Gadgets ***
    public DbSet<Gadget> Gadgets { get; set; } = null!;

    //*** Gadgets.GadgetTypes ***
    public DbSet<GadgetType> GadgetTypes { get; set; } = null!;

    //*** Gadgets.ProcedureReults (Keyless) ***
    public DbSet<GadgetsGridItem> GadgetsGridItems { get; set; } = null!;

    //*** Inspections ***
    public DbSet<Inspection> Inspections { get; set; } = null!;

    //*** Technicians ***
    public DbSet<Technician> Technicians { get; set; } = null!;

    //*** Test (Keyless Procedure Results) ***
    //public DbSet<Test> Test { get; set; } = null!;

    //*** Users ***
    public DbSet<User> Users { get; set; } = null!;
    #endregion

    #region Ctor
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {

    }
    #endregion

    #region Overrides
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //This tells EF to look for all IEntityTypeConfiguration classes in the project.
        //You can use any class here as an example to get the assembly
        //We choose GadgetType as our example
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GadgetTypeMap).Assembly);

        SeedHelper.SeedData(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //This converts all DateTime objects in our model to UTC.
        //You'll see the time as a string gets a "Z" appended to it
        //When you do a new Date(dateString).toLocaleString() in JavaScript, it recognizes it as UTC
        //and converts it to the local timezone of the client
        configurationBuilder.Properties<DateTime>().HaveConversion<UtcValueConverter>();

        //Not unicode (varchar) by default
        //Opt-in to Unicode (nvarchar) for specific fields that require it
        configurationBuilder.Properties<string>().AreUnicode(false);
    }
    #endregion
}
