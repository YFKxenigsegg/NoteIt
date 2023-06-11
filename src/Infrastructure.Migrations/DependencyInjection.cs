namespace NoteIt.Infrastructure.Migrations;
public static class DependencyInjection
{
    public static IServiceCollection AddMigrations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore()
            .ConfigureRunner(config => config.AddSqlServer()
                .WithGlobalConnectionString(configuration.GetConnectionString("DefaultConnection"))
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations().For.EmbeddedResources())
            .AddLogging(x => x.AddFluentMigratorConsole().AddNLog());

        using var scope = services.BuildServiceProvider().CreateScope();
        var runner  = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();

        return services;
    }
}
