using GadgetInspector.Framework;
using GadgetInspector.Server.DataProviders.Gadgets;
using GadgetInspector.Server.DataProviders.GadgetTypes;
using GadgetInspector.Server.DataProviders.Inspections;
using GadgetInspector.Server.DataProviders.Technicians;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GadgetInspector.Server.Configurators;

public class ServiceConfigurator
{
    public static void Configure(IServiceCollection services, IConfiguration config)
    {
        ConfigureConfigs(services, config);
        ConfigureDataProviders(services);
        ConfigureServices(services, config);
    }

    #region ConfigureConfigs Support
    private static void ConfigureConfigs(IServiceCollection services, IConfiguration config)
    {
        DependencyRegistrar.ConfigureConfigs(services, config);
    }
    #endregion

    #region ConfigureDataProviders Support
    private static void ConfigureDataProviders(IServiceCollection services)
    {
        ////*** Inspections ***
        services.TryAddScoped<IInspectionDataProvider, InspectionDataProvider>();

        ////*** Gadgets ***
        services.TryAddScoped<IGadgetDataProvider, GadgetDataProvider>();

        ////*** Gadgets.GadgetTypes ***
        services.TryAddScoped<IGadgetTypeDataProvider, GadgetTypeDataProvider>();

        ////*** Technicians ***
        services.TryAddScoped<ITechnicianDataProvider, TechnicianDataProvider>();
    }
    #endregion

    #region ConfigureServices Support
    private static void ConfigureServices(IServiceCollection services, IConfiguration config)
    {
        ConfigureProjectServices(services, config); //Services specific to this project
        DependencyRegistrar.ConfigureServices(services, config); //Services from Framework.DependencyRegistrar
    }

    private static void ConfigureProjectServices(IServiceCollection services, IConfiguration config)
    {
        //Probably skipping AutoMapper for today
        //ConfigureAutoMapper(services);
    }
    #endregion
}
