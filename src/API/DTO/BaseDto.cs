using Domain.Interfaces;

namespace API.DTO;

public class BaseDto : IBaseDto
{
    public Guid? Id { get; set; }
}