using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using UUIDNext;

namespace Infrastructure.Data.Core;

/// <summary>
/// Custom UUID generator using UUIDNext to generate sequential Guid.
/// </summary>
public class SequentialUuidGenerator : ValueGenerator<Guid>
{
    public override bool GeneratesTemporaryValues => false;

    public override Guid Next(EntityEntry entry)
    {
        return Uuid.NewDatabaseFriendly(Database.PostgreSql);
    }
}