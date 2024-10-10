using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Extensions;

public static class AppDbContextExtensions
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<AppDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("ConnectionString")));
    }
}