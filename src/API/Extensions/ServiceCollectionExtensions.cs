using API.Services;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Infrastructure.IA;

namespace API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services.AddSingleton<IAService>()
                .AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
        }

        public static IServiceCollection AddUserResolverService(this IServiceCollection services)
        {

            return services.AddHttpContextAccessor()
                .AddTransient<IUserResolverService, UserResolverService>();
        }
    }
}