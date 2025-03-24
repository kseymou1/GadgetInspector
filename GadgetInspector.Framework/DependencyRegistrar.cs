using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using GadgetInspector.Core.Options.ConnectionStrings;
using GadgetInspector.Services;
using GadgetInspector.Data;
using GadgetInspector.Services.GadgetTypes;
using GadgetInspector.Services.Gadgets;
using GadgetInspector.Services.Technicians;
using GadgetInspector.Services.Inspections;

namespace GadgetInspector.Framework;

public static class DependencyRegistrar
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration config)
    {
        ConfigureDatabase(services, config);
        ConfigureServices(services);
    }

    /// <summary>
    /// Configures options for use with IOptions
    /// The configurations must be defined in the application that calls this method
    /// For example, appSettings.json in the web project
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    public static void ConfigureConfigs(IServiceCollection services, IConfiguration config)
    {
        //*** ConnectionString ***
        _ = services.Configure<ConnectionStringOptions>(o => config.GetSection("ConnectionStrings").Bind(o));
    }

    #region ConfigureServices Support
    private static void ConfigureDatabase(IServiceCollection services, IConfiguration config)
    {
        _ = services.AddDbContext<MainDbContext>(optionsBuilder =>
        {
            string connectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");

            //https://devblogs.microsoft.com/dotnet/introducing-the-reliable-web-app-pattern/
            optionsBuilder.UseSqlServer(connectionString: connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(3),
                    errorNumbersToAdd: null);
            });
        }, ServiceLifetime.Scoped);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // *** (Root) ***
        services.TryAddScoped<IServiceCommon, ServiceCommon>();

        ////*** Inspections ***
        services.TryAddScoped<IInspectionService, InspectionService>();

        ////*** Gadgets ***
        services.TryAddScoped<IGadgetsGridService, GadgetsGridService>();

        ////*** Gadgets.GadgetTypes ***
        services.TryAddScoped<IGadgetTypeService, GadgetTypeService>();

        ////*** Technicians ***
        services.TryAddScoped<ITechnicianService, TechnicianService>();

        //*** Users ***
        //services.TryAddScoped<IUserService, UserService>();
    }
    #endregion
}
