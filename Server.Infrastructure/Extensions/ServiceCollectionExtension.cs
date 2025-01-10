using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Common.Interfaces.Persistence;
using Server.Infrastructure.Persistence;
using Server.Infrastructure.Repositories;

namespace Server.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging());

        return services;
    }
}
