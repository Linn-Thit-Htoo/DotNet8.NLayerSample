using DotNet8.NLayerSample.BusinessLogic.Services;
using DotNet8.NLayerSample.DataAccess.Services;
using DotNet8.NLayerSample.DbService;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.NLayerSample.Presentation.Services;

public static class ModularService
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        services
            .AddDbContextService(builder)
            .AddBusinessLogicServices()
            .AddDataAccessServices()
            .AddJsonServices();

        return services;
    }

    private static IServiceCollection AddDbContextService(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        builder.Services.AddDbContext<AppDbContext>(
            opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            },
            ServiceLifetime.Transient
        );

        return services;
    }

    private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<BL_Blog>();
        return services;
    }

    private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<DA_Blog>();
        return services;
    }

    private static IServiceCollection AddJsonServices(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        return services;
    }
}