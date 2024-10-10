namespace Domain.Exceptions;

public class EntityNotValidException : Exception
{
    public EntityNotValidException()
    {
    }

    public EntityNotValidException(string message)
        : base(message)
    {
    }
}