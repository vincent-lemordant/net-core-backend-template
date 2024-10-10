using Domain.Entities;

namespace Infrastructure.Data.Repositories
{
    public class InitiativeRepository(AppDbContext dbContext) : BaseRepository<Initiative>(dbContext)
    {
    }
}