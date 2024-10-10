
namespace Domain.Interfaces;

/// <summary>
/// Get the current user, i.e. the user making the HTTP call. 
/// </summary>
public interface IUserResolverService
{
    public string? GetUser();
}