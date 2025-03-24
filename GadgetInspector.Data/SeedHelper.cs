using GadgetInspector.Core.Constants.Gadgets.GadgetTypes;
using GadgetInspector.Core.Domain.GadgetTypes;
using Microsoft.EntityFrameworkCore;

namespace GadgetInspector.Data;

//See: https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
internal static class SeedHelper
{
    #region Main Method
    internal static void SeedData(ModelBuilder modelBuilder)
    {
        SeedGadgetType(modelBuilder);
    }
    #endregion

    #region GadgetType
    private static void SeedGadgetType(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GadgetType>().HasData(
            new GadgetType() { Id = GadgetTypeIds.Breaker, Name = "Breaker", InspectionIntervalDays = 90 },
            new GadgetType() { Id = GadgetTypeIds.Transformer, Name = "Transformer", InspectionIntervalDays = 90 },
            new GadgetType() { Id = GadgetTypeIds.StartingTransformer, Name = "Starting Transformer", InspectionIntervalDays = 90 },
            new GadgetType() { Id = GadgetTypeIds.Boiler, Name = "Boiler", InspectionIntervalDays = 90 },
            new GadgetType() { Id = GadgetTypeIds.Pump, Name = "Pump", InspectionIntervalDays = 90 },
            new GadgetType() { Id = GadgetTypeIds.Turbine, Name = "Turbine", InspectionIntervalDays = 90 }
       );
    }
    #endregion
}
