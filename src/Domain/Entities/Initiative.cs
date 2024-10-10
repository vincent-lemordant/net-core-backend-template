using Domain.Base;

namespace Domain.Entities;

public class Initiative : BaseEntity
{
    public string? Name { get; set; }

    public override string? GenerateInstanceLabel()
    {
        return Name;
    }

    public override bool TryCheckCreate()
    {
        return !string.IsNullOrWhiteSpace(Name);
    }
}
