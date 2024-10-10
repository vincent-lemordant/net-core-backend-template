
using Domain.Interfaces;

namespace API;

public class UserResolverService : IUserResolverService
{
    private readonly IHttpContextAccessor _context;
    public UserResolverService(IHttpContextAccessor context)
    {
        _context = context;
    }

    public string? GetUser()
    {
        return _context.HttpContext?.User?.Identity?.Name;
    }
}