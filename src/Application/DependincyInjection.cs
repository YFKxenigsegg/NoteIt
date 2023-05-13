using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Note.Infrastructure.Persistence.Helpers;
using Note.Infrastructure.Persistence.Helpers.Interfaces;

namespace Note.Application;
public static class DependincyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeHelper, DateTimeHelper>();

        return services;
    }
}
