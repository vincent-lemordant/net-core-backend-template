using API.Extensions;
using API.Mappings;
using API.Services;
using Infrastructure.Data.Extensions;

namespace API;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddRouting(options => options.LowercaseUrls = true);

        if (env.IsDevelopment())
        {
            // Add CORS for local development.
            services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
                });
        }

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddControllers().AddNewtonsoftJson();
        services.AddSwaggerGen();

        // Auto Mapper Configuration
        services.AddAutoMapper(typeof(MappingProfile));

        // Application services
        services.AddApplicationDbContext(Configuration)
                .AddRepositories()
                .AddBusinessServices()
                .AddUserResolverService()
                .AddHostedService<IALoaderService>();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            // Add CORS for local development.
            app.UseCors();
        }

        app.MapControllers();

        // To use PostgreSQL date without specifying Zone.
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}
