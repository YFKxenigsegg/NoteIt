using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NoteIt.Application.Abstractions;
using NoteIt.Application.Contracts.Persistence;
using NoteIt.Application.Models;
using NoteIt.Auth.Identity;
using NoteIt.Domain.Entities;
using NoteIt.Infrastructure.Authentication;
using NoteIt.Infrastructure.Identity;
using NoteIt.Infrastructure.Options;
using NoteIt.Infrastructure.Persistence;
using NoteIt.Infrastructure.Persistence.Repositories;
using System.Net;

namespace NoteIt.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                providerOptions => providerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
            .EnableSensitiveDataLogging(true)
        );

        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddTransient<IJwtProvider, JwtProvider>();

        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();

        //identity
        var authOptionsSection = configuration.GetSection("AuthOptions");
        services.AddOptions();
        services.Configure<AuthOptions>(authOptionsSection);

        services.AddScoped<IPasswordHasher<ApplicationUser>, SaltedPasswordHasher>();
        services.AddScoped<ILookupNormalizer, KeyNormalizer>();

        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.Lockout.MaxFailedAccessAttempts = 5;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                var authOptons = authOptionsSection.Get<AuthOptions>();
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer = authOptons!.Issuer,
                    ValidateAudience = true,
                    ValidAudience = authOptons.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = authOptons.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new()
                {
                    OnAuthenticationFailed = context =>
                    {
                        context.NoResult();
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Response.ContentType = "application/json";
                        context.Response.WriteAsync(JsonConvert.SerializeObject(new Error("error", "Token expired. Please, authorize."))).Wait();
                        return Task.CompletedTask;
                    }
                };
            });

        //services.AddTransient<IUserStore<ApplicationUser>, UserStore>();
        //services.AddTransient<IUserEmailStore<ApplicationUser>, UserStore>();
        //services.AddTransient<IRoleStore<ApplicationRole>, RoleStore>();

        return services;
    }
}
