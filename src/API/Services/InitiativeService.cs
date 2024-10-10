using Domain.Entities;
using Domain.Interfaces;

namespace API.Services
{
    public class InitiativeService(IBaseRepository<Initiative> repository) : BaseService<Initiative>(repository)
    {
    }
}