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

        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();

        services.AddTransient<IJwtProvider, JwtProvider>();

        var authOptionsSection = configuration.GetSection("AuthOptions");
        services.AddOptions();
        services.Configure<AuthOptions>(authOptionsSection);

        services.AddScoped<IPasswordHasher<User>, SaltedPasswordHasher>();
        services.AddScoped<ILookupNormalizer, KeyNormalizer>();

        services.AddIdentity<User, IdentityRole>(opt =>
        {
            opt.Password.RequireDigit = true;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireNonAlphanumeric = true;
            opt.Password.RequireUppercase = true;
            opt.Password.RequiredLength = 8;
            opt.Lockout.MaxFailedAccessAttempts = 5;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(opt =>
            {
                var authOptons = authOptionsSection.Get<AuthOptions>();
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidIssuer = authOptons!.Issuer,
                    ValidateAudience = false,
                    ValidAudience = authOptons.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = authOptons.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };
                opt.Events = new()
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

        return services;
    }
}
