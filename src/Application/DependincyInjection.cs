﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteIt.Infrastructure.Persistence.Helpers;
using NoteIt.Infrastructure.Persistence.Helpers.Interfaces;

namespace NoteIt.Application;
public static class DependincyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeHelper, DateTimeHelper>();

        return services;
    }
}
