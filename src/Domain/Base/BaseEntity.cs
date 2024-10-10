namespace Domain.Base;

/// <summary>
/// Base entity of the app, all entites must inherit it.
/// </summary>
public abstract class BaseEntity
{
    public Guid? Id { get; set; }

    public string? InstanceLabel { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual bool TryCheckCreate()
    {
        return true;
    }
    public abstract string? GenerateInstanceLabel();
}
