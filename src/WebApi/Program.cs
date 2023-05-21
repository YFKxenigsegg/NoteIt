using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Note.Application;
using Note.Auth;
using Note.Infrastructure;
using Note.Infrastructure.Exceptions.Filter;
using Note.Infrastructure.Migrations;
using Note.Infrastructure.Persistence;
using NLog;
using NLog.Web;
using NSwag;
using NSwag.Generation.Processors.Security;
using FluentValidation.AspNetCore;

var _logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
_logger.Debug("init main");
try
{
    var builder = WebApplication.CreateBuilder(args);
    {
        builder.Services.AddLogging();
        builder.Logging.AddNLog("NLog.config");

        builder.Services.AddApplication(builder.Configuration);
        builder.Services.AddIdentity(builder.Configuration);
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddMigrations(builder.Configuration);

        builder.Services.AddControllers(optons =>
            optons.Filters.Add(new ApiExceptionFilter()));

        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddMediatR(config =>
            config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName != null && x.FullName.Contains("Note")).ToArray()));

        builder.Services.AddOpenApiDocument(config =>
        {
            config.Title = "Mirfin API";
            config.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });
            config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });

        builder.Services.AddAutoMapper((serviceProvider, autoMapper) =>
        {
            autoMapper.AddCollectionMappers();
            autoMapper.UseEntityFrameworkCoreModel<ApplicationDbContext>(serviceProvider);
        }, GetAutoMapperProfilesFromAllAssemblies().ToArray());

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    var app = builder.Build();
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.MapControllers();

        app.UseOpenApi();
        app.UseSwaggerUi3();
    }
    app.Run();

    static IEnumerable<Type> GetAutoMapperProfilesFromAllAssemblies()
    {
        return from assembly in AppDomain.CurrentDomain.GetAssemblies()
               from aType in assembly.GetTypes()
               where aType.IsClass && !aType.IsAbstract && aType.IsSubclassOf(typeof(Profile))
               select aType;
    }
}
catch (Exception ex)
{
    _logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}