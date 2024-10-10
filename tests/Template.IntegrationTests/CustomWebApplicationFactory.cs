using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template.IntegrationTests;

/// <summary>
/// Create a custom TestServer using Fixture.
/// See : https://xunit.net/docs/shared-context#class-fixture
/// </summary>
/// <typeparam name="TStartup"></typeparam>
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Override the connection string to target the test database.
        // See : https://stackoverflow.com/a/72748115/6415516
        var configurationValues = new Dictionary<string, string?>
        {
            { "ConnectionStrings:ConnectionString", "Host=localhost;Username=yourUser;Password=changeit;Database=test_database" }
        };
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configurationValues)
            .Build();

        builder
            // This configuration is used during the creation of the application
            // (e.g. BEFORE WebApplication.CreateBuilder(args) is called in Program.cs).
            .UseConfiguration(configuration)
            .ConfigureAppConfiguration(configurationBuilder =>
            {
                // This overrides configuration settings that were added as part 
                // of building the Host (e.g. calling WebApplication.CreateBuilder(args)).
                configurationBuilder.AddInMemoryCollection(configurationValues);
            });


        // Drop and create the database to have a clean context for tests.
        builder.ConfigureServices(services =>
        {
            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();
                // Drop
                db.Database.EnsureDeleted();
                // Create
                db.Database.EnsureCreated();
            }
        });

        // To use PostgreSQL date without specifying Zone.
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}